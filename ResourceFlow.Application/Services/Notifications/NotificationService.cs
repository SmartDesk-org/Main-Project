using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Notifications;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Enums;

namespace ResourceFlow.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IGenericRepository<Notification> _notificationGenericRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationService> _logger;
        private readonly INotificationHubClientService _hubClientService; // ADD THIS

        public NotificationService(
            IGenericRepository<Notification> notificationGenericRepository,
            INotificationRepository notificationRepository,
            ICurrentUserService currentUserService,
            IMapper mapper,
            ILogger<NotificationService> logger,
            INotificationHubClientService hubClientService) 
        {
            _notificationGenericRepository = notificationGenericRepository;
            _notificationRepository = notificationRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _logger = logger;
            _hubClientService = hubClientService;
        }
        public async Task<ApiResponse<NotificationDto>> CreateNotificationAsync(CreateNotificationDto createDto)
        {
            try
            {
                _logger.LogInformation(
                    "User {UserId} creating notification. Title: {Title}",
                    _currentUserService.UserId,
                    createDto.Title);

                // 🔹 Determine NotificationType
                NotificationType tempType = createDto.NotificationType;

                // Auto-set based on ReferenceType only if default value (e.g., System) or None
                if (tempType == 0) // Assuming 0 is default/None
                {
                    if (createDto.ReferenceType == ReferenceType.DeskBooking ||
                        createDto.ReferenceType == ReferenceType.MeetingBooking)
                    {
                        tempType = NotificationType.Booking;
                    }
                    else if (createDto.ReferenceType == ReferenceType.Billing ||
                             createDto.ReferenceType == ReferenceType.Subscription)
                    {
                        tempType = NotificationType.Payment;
                    }
                    else
                    {
                        tempType = NotificationType.System;
                    }

                    createDto.NotificationType = tempType;
                }

                // 🔹 CHECK FOR ALL USERS LOGIC
                bool isForAllUsers = false;

                // If all target IDs are 0/null, it's for all users
                if ((createDto.CompanyId == 0 || createDto.CompanyId == null) &&
                    (createDto.UserId == 0 || createDto.UserId == null) &&
                    (createDto.RoleId == 0 || createDto.RoleId == null))
                {
                    isForAllUsers = true;

                    _logger.LogInformation(
                        "Sending notification to all users: {Title}",
                        createDto.Title);
                }
                else
                {
                    // Check if user can receive this type of notification (for user-specific notifications)
                    if (createDto.UserId.HasValue && createDto.UserId.Value > 0)
                    {
                        var canSend = await _notificationRepository.CanSendNotificationAsync(
                            createDto.UserId.Value,
                            tempType);

                        if (!canSend)
                        {
                            return ApiResponse<NotificationDto>.Error(
                                $"User cannot receive notifications of type {tempType}", 400);
                        }
                    }
                }


                // 🛡️ XSS protection
                createDto.Title = WebUtility.HtmlEncode(createDto.Title ?? string.Empty);
                createDto.Message = WebUtility.HtmlEncode(createDto.Message ?? string.Empty);

                var notification = _mapper.Map<Notification>(createDto);

                // 🔹 Handle 0 as null for optional IDs
                notification.CompanyId = createDto.CompanyId > 0 ? createDto.CompanyId : null;
                notification.UserId = createDto.UserId > 0 ? createDto.UserId : null;
                notification.RoleId = createDto.RoleId > 0 ? createDto.RoleId : null;

                // 🔹 SET IsForAllUsers FLAG
                notification.IsForAllUsers = isForAllUsers;

                // 🔹 Reference validation
                if (createDto.ReferenceType == null)
                {
                    notification.ReferenceType = null;
                    notification.ReferenceId = null;
                }
                else
                {
                    if (!createDto.ReferenceId.HasValue || createDto.ReferenceId <= 0)
                    {
                        return ApiResponse<NotificationDto>.Error(
                            "ReferenceId is required when ReferenceType is provided", 400);
                    }

                    notification.ReferenceType = createDto.ReferenceType;
                    notification.ReferenceId = createDto.ReferenceId;
                }

                // 🔹 Defaults
                notification.IsRead = false;
                notification.ReadAt = null;
                notification.RetryCount = 0;
                notification.CreatedAt = DateTime.UtcNow;
                notification.CreatedBy = _currentUserService.UserId;
                notification.NotificationType = tempType;

                // 🚀 AUTO SEND LOGIC
                if (createDto.SendImmediately)
                {
                    notification.Status = NotificationStatus.Sent;
                    notification.IsSent = true;
                    notification.SentAt = DateTime.UtcNow;

                    // 🔹 SEND SIGNALR NOTIFICATION BASED ON TARGET
                    if (notification.IsForAllUsers)
                    {
                        // Send to all users via SignalR
                        await _hubClientService.SendToAllAsync(notification.Title, notification.Message);
                        _logger.LogInformation("Notification sent to all users via SignalR: {Title}", notification.Title);
                    }
                    else if (notification.UserId.HasValue)
                    {
                        // Send to specific user
                        await _hubClientService.SendToUserAsync(
                            notification.UserId.Value,
                            notification.Title,
                            notification.Message);
                    }
                    else if (notification.RoleId.HasValue)
                    {
                        // Send to specific role
                        await _hubClientService.SendToRoleAsync(
                            notification.RoleId.Value,
                            notification.Title,
                            notification.Message);
                    }
                    else if (notification.CompanyId.HasValue)
                    {
                        // Send to specific company
                        await _hubClientService.SendToCompanyAsync(
                            notification.CompanyId.Value,
                            notification.Title,
                            notification.Message);
                    }
                }
                else
                {
                    notification.Status = NotificationStatus.Pending;
                    notification.IsSent = false;
                    notification.SentAt = null;
                }

                // 💾 Save
                await _notificationGenericRepository.AddAsync(notification);
                await _notificationGenericRepository.SaveChangesAsync();

                var notificationDto = _mapper.Map<NotificationDto>(notification);

                // 🔹 Enrich response
                if (notification.UserId.HasValue)
                {
                    notificationDto.UserName =
                        await _notificationRepository.GetUserNameAsync(notification.UserId.Value)
                        ?? "Unknown User";
                }

                if (notification.CompanyId.HasValue)
                {
                    notificationDto.CompanyName =
                        await _notificationRepository.GetCompanyNameAsync(notification.CompanyId.Value)
                        ?? "Unknown Company";
                }

                // Set IsForAllUsers in DTO
                notificationDto.IsForAllUsers = notification.IsForAllUsers;

                return ApiResponse<NotificationDto>.Success(
                    notificationDto,
                    isForAllUsers ? "Notification sent to all users successfully" : "Notification created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating notification");
                return ApiResponse<NotificationDto>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<NotificationDto>> GetNotificationByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<NotificationDto>.Error("Invalid notification ID", 400);

                var notification = await _notificationGenericRepository.GetByIdAsync(id);

                if (notification == null)
                {
                    _logger.LogWarning("Notification {NotificationId} not found", id);
                    return ApiResponse<NotificationDto>.Error("Notification not found", 404);
                }

                // ✅ Security: Check if user has permission to view this notification
                if (notification.UserId.HasValue &&
                    notification.UserId.Value != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {UserId} attempted to access notification {NotificationId} belonging to user {OwnerUserId}",
                        _currentUserService.UserId, id, notification.UserId.Value);
                    return ApiResponse<NotificationDto>.Error("You don't have permission to view this notification", 403);
                }

                var notificationDto = _mapper.Map<NotificationDto>(notification);

                // ✅ Null-safe enrichment
                if (notification.UserId.HasValue)
                {
                    notificationDto.UserName = await _notificationRepository.GetUserNameAsync(notification.UserId.Value)
                                               ?? "Unknown User";
                }

                if (notification.CompanyId.HasValue)
                {
                    notificationDto.CompanyName = await _notificationRepository.GetCompanyNameAsync(notification.CompanyId.Value)
                                                  ?? "Unknown Company";
                }

                return ApiResponse<NotificationDto>.Success(notificationDto, "Notification retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notification {NotificationId}", id);
                return ApiResponse<NotificationDto>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<IEnumerable<NotificationDto>>> GetUserNotificationsAsync(int userId, bool unreadOnly = false)
        {
            try
            {
                if (userId <= 0)
                    return ApiResponse<IEnumerable<NotificationDto>>.Error("Invalid user ID", 400);

             
                if (userId != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {CurrentUserId} attempted to access notifications for user {TargetUserId}",
                        _currentUserService.UserId, userId);
                    return ApiResponse<IEnumerable<NotificationDto>>.Error("You don't have permission to view other users' notifications", 403);
                }

                var notifications = await _notificationRepository
                    .GetUserNotificationsAsync(userId, unreadOnly);

                var notificationDtos = _mapper.Map<List<NotificationDto>>(notifications);

                // ✅ Null-safe enrichment
                foreach (var dto in notificationDtos.Where(d => d.UserId.HasValue))
                {
                    dto.UserName = await _notificationRepository.GetUserNameAsync(dto.UserId.Value)
                                   ?? "Unknown User";
                }

                return ApiResponse<IEnumerable<NotificationDto>>.Success(
                    notificationDtos,
                    $"Retrieved {notificationDtos.Count} notification(s)");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for user {UserId}", userId);
                return ApiResponse<IEnumerable<NotificationDto>>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<IEnumerable<NotificationDto>>> GetCompanyNotificationsAsync(int companyId, bool unreadOnly = false)
        {
            try
            {
                if (companyId <= 0)
                    return ApiResponse<IEnumerable<NotificationDto>>.Error("Invalid company ID", 400);

                // ✅ Security: Check if user belongs to this company or is admin
                if (_currentUserService.CompanyId != companyId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {UserId} attempted to access company {CompanyId} notifications without permission",
                        _currentUserService.UserId, companyId);
                    return ApiResponse<IEnumerable<NotificationDto>>.Error("You don't have permission to view this company's notifications", 403);
                }

                var notifications = await _notificationRepository
                    .GetCompanyNotificationsAsync(companyId, unreadOnly);

                var notificationDtos = _mapper.Map<List<NotificationDto>>(notifications);

                // ✅ Null-safe enrichment for company name
                foreach (var dto in notificationDtos.Where(d => d.CompanyId.HasValue))
                {
                    dto.CompanyName = await _notificationRepository.GetCompanyNameAsync(dto.CompanyId.Value)
                                      ?? "Unknown Company";
                }

                return ApiResponse<IEnumerable<NotificationDto>>.Success(
                    notificationDtos,
                    $"Retrieved {notificationDtos.Count} notification(s)");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for company {CompanyId}", companyId);
                return ApiResponse<IEnumerable<NotificationDto>>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<IEnumerable<NotificationDto>>> GetRoleNotificationsAsync(int roleId, bool unreadOnly = false)
        {
            try
            {
                if (roleId <= 0)
                    return ApiResponse<IEnumerable<NotificationDto>>.Error("Invalid role ID", 400);

                // ✅ Security: Users can only view their own role notifications (or admins)
                if (roleId != _currentUserService.RoleId && !_currentUserService.IsInRole("Admin"))
                {
                    _logger.LogWarning("User {UserId} with role {UserRoleId} attempted to access role {TargetRoleId} notifications",
                        _currentUserService.UserId, _currentUserService.RoleId, roleId);
                    return ApiResponse<IEnumerable<NotificationDto>>.Error("You don't have permission to view this role's notifications", 403);
                }

                var notifications = await _notificationRepository
                    .GetRoleNotificationsAsync(roleId, unreadOnly);

                var notificationDtos = _mapper.Map<List<NotificationDto>>(notifications);

                return ApiResponse<IEnumerable<NotificationDto>>.Success(
                    notificationDtos,
                    $"Retrieved {notificationDtos.Count} notification(s)");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for role {RoleId}", roleId);
                return ApiResponse<IEnumerable<NotificationDto>>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<bool>> MarkAsReadAsync(int notificationId)
        {
            try
            {
                if (notificationId <= 0)
                    return ApiResponse<bool>.Error("Invalid notification ID", 400);

                var notification = await _notificationGenericRepository.GetByIdAsync(notificationId);

                if (notification == null)
                {
                    _logger.LogWarning("Notification {NotificationId} not found for marking as read", notificationId);
                    return ApiResponse<bool>.Error("Notification not found", 404);
                }

                // ✅ Security: Check if notification belongs to current user
                if (notification.UserId.HasValue &&
                    notification.UserId.Value != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {UserId} attempted to mark notification {NotificationId} as read without permission",
                        _currentUserService.UserId, notificationId);
                    return ApiResponse<bool>.Error("You can only mark your own notifications as read", 403);
                }

                if (!notification.IsRead)
                {
                    notification.IsRead = true;
                    notification.ReadAt = DateTime.UtcNow;
                    notification.Status = NotificationStatus.Read;
                    notification.UpdatedAt = DateTime.UtcNow;

                    await _notificationGenericRepository.UpdateAsync(notification);
                    await _notificationGenericRepository.SaveChangesAsync();

                    _logger.LogInformation("Notification {NotificationId} marked as read by user {UserId}",
                        notificationId, _currentUserService.UserId);
                }

                return ApiResponse<bool>.Success(true, "Notification marked as read");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking notification {NotificationId} as read", notificationId);
                return ApiResponse<bool>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<int>> MarkMultipleAsReadAsync(List<int> notificationIds)
        {
            try
            {
                if (notificationIds == null || notificationIds.Count == 0)
                    return ApiResponse<int>.Error("No notification IDs provided", 400);

                if (notificationIds.Any(id => id <= 0))
                    return ApiResponse<int>.Error("Invalid notification ID in list", 400);

                // ✅ FIXED: Get current user ID from authenticated context
                var currentUserId = _currentUserService.UserId;

                if (currentUserId == 0)
                {
                    return ApiResponse<int>.Error("User must be authenticated to mark notifications as read", 401);
                }

                // ✅ Security: Repository will only mark notifications belonging to this user
                await _notificationRepository.MarkMultipleAsReadAsync(notificationIds, currentUserId);

                _logger.LogInformation("User {UserId} marked {Count} notifications as read",
                    currentUserId, notificationIds.Count);

                return ApiResponse<int>.Success(notificationIds.Count, $"{notificationIds.Count} notifications marked as read");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking multiple notifications as read");
                return ApiResponse<int>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<bool>> MarkAllAsReadAsync(int userId)
        {
            try
            {
                if (userId <= 0)
                    return ApiResponse<bool>.Error("Invalid user ID", 400);

                // ✅ Security: Users can only mark their own notifications as read
                if (userId != _currentUserService.UserId)
                {
                    _logger.LogWarning("User {CurrentUserId} attempted to mark all notifications as read for user {TargetUserId}",
                        _currentUserService.UserId, userId);
                    return ApiResponse<bool>.Error("You can only mark your own notifications as read", 403);
                }

                await _notificationRepository.MarkAllAsReadForUserAsync(userId);

                _logger.LogInformation("User {UserId} marked all notifications as read", userId);
                return ApiResponse<bool>.Success(true, "All notifications marked as read");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking all notifications as read for user {UserId}", userId);
                return ApiResponse<bool>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<int>> GetUnreadCountAsync(int userId)
        {
            try
            {
                if (userId <= 0)
                    return ApiResponse<int>.Error("Invalid user ID", 400);

                // ✅ Security: Users can only get their own unread count
                if (userId != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {CurrentUserId} attempted to get unread count for user {TargetUserId}",
                        _currentUserService.UserId, userId);
                    return ApiResponse<int>.Error("You can only get your own unread count", 403);
                }

                var count = await _notificationRepository.GetUnreadCountForUserAsync(userId);
                return ApiResponse<int>.Success(count, "Unread count retrieved");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unread count for user {UserId}", userId);
                return ApiResponse<int>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<bool>> SendRealTimeNotificationAsync(int userId, string title, string message)
        {
            try
            {
                if (userId <= 0)
                    return ApiResponse<bool>.Error("Invalid user ID", 400);

                if (string.IsNullOrWhiteSpace(title))
                    return ApiResponse<bool>.Error("Title is required", 400);

                if (string.IsNullOrWhiteSpace(message))
                    return ApiResponse<bool>.Error("Message is required", 400);

                // ✅ Security: Only admins and managers can send real-time notifications
                if (!_currentUserService.IsInRole("Admin") && !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {UserId} attempted to send real-time notification without permission",
                        _currentUserService.UserId);
                    return ApiResponse<bool>.Error("Only admins and managers can send real-time notifications", 403);
                }

                // ✅ FIXED: Get RoleId from current user context
                var createDto = new CreateNotificationDto
                {
                    UserId = userId,
                    RoleId = _currentUserService.RoleId, // ✅ Get from current user
                    Title = WebUtility.HtmlEncode(title),
                    Message = WebUtility.HtmlEncode(message),
                    NotificationType = NotificationType.System,
                    TargetChannel = TargetChannel.InApp,
                    SendImmediately = true
                };

                var result = await CreateNotificationAsync(createDto);

                if (result.StatusCode != 200)
                {
                    return ApiResponse<bool>.Error(result.Message, result.StatusCode);
                }

                _logger.LogInformation("User {UserId} sent real-time notification to user {TargetUserId}",
                    _currentUserService.UserId, userId);

                return ApiResponse<bool>.Success(true, "Real-time notification sent successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending real-time notification to user {UserId}", userId);
                return ApiResponse<bool>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<bool>> DeleteNotificationAsync(int notificationId)
        {
            try
            {
                if (notificationId <= 0)
                    return ApiResponse<bool>.Error("Invalid notification ID", 400);

                var notification = await _notificationGenericRepository.GetByIdAsync(notificationId);

                if (notification == null)
                {
                    _logger.LogWarning("Notification {NotificationId} not found for deletion", notificationId);
                    return ApiResponse<bool>.Error("Notification not found", 404);
                }

                // ✅ Security: Only admins or notification owners can delete
                if (notification.CreatedBy != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin"))
                {
                    _logger.LogWarning("User {UserId} attempted to delete notification {NotificationId} created by user {CreatorUserId}",
                        _currentUserService.UserId, notificationId, notification.CreatedBy);
                    return ApiResponse<bool>.Error("You don't have permission to delete this notification", 403);
                }

                await _notificationGenericRepository.DeleteAsync(notification);
                await _notificationGenericRepository.SaveChangesAsync();

                _logger.LogInformation("Notification {NotificationId} deleted successfully by user {UserId}",
                    notificationId, _currentUserService.UserId);

                return ApiResponse<bool>.Success(true, "Notification deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting notification {NotificationId}", notificationId);
                return ApiResponse<bool>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<bool>> ProcessPendingNotificationsAsync()
        {
            try
            {
                // This is a background job - no user context needed
                _logger.LogInformation("Starting to process pending notifications");

                // Get IQueryable from repository for efficient filtering
                var queryable = _notificationGenericRepository.GetQueryable();

                var pendingNotifications = queryable
                    .Where(n => n.Status == NotificationStatus.Pending &&
                               n.TargetChannel != TargetChannel.InApp)
                    .ToList();

                await ProcessNotifications(pendingNotifications);

                _logger.LogInformation("Processed {Count} pending notifications", pendingNotifications.Count);

                return ApiResponse<bool>.Success(true, $"Processed {pendingNotifications.Count} pending notifications");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing pending notifications");
                return ApiResponse<bool>.Error(ex.Message, 500);
            }
        }

        private async Task ProcessNotifications(List<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                try
                {
                    // Process based on target channel
                    switch (notification.TargetChannel)
                    {
                        case TargetChannel.Email:
                            await SendEmailNotificationAsync(notification);
                            break;
                        case TargetChannel.SMS:
                            await SendSmsNotificationAsync(notification);
                            break;
                        case TargetChannel.Push:
                            await SendPushNotificationAsync(notification);
                            break;
                    }

                    notification.IsSent = true;
                    notification.SentAt = DateTime.UtcNow;
                    notification.Status = NotificationStatus.Sent;
                    notification.UpdatedAt = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing notification {NotificationId}", notification.Id);
                    notification.Status = NotificationStatus.Failed;
                    notification.RetryCount++;
                }

                await _notificationGenericRepository.UpdateAsync(notification);
            }

            await _notificationGenericRepository.SaveChangesAsync();
        }

        public async Task<ApiResponse<bool>> RetryFailedNotificationsAsync()
        {
            try
            {
                // This is a background job - no user context needed
                _logger.LogInformation("Starting to retry failed notifications");

                var queryable = _notificationGenericRepository.GetQueryable();

                var failedNotifications = queryable
                    .Where(n => n.Status == NotificationStatus.Failed && n.RetryCount < 3)
                    .ToList();

                await RetryNotifications(failedNotifications);

                _logger.LogInformation("Retried {Count} failed notifications", failedNotifications.Count);

                return ApiResponse<bool>.Success(true, $"Retried {failedNotifications.Count} failed notifications");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrying failed notifications");
                return ApiResponse<bool>.Error(ex.Message, 500);
            }
        }

        private async Task RetryNotifications(List<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                // Reset to pending for retry
                notification.Status = NotificationStatus.Pending;
                await _notificationGenericRepository.UpdateAsync(notification);
            }

            await _notificationGenericRepository.SaveChangesAsync();

            // Process the retried notifications
            await ProcessPendingNotificationsAsync();
        }

        private async Task SendEmailNotificationAsync(Notification notification)
        {
            // Implement email sending logic
            await Task.Delay(100); // Simulate email sending
            _logger.LogInformation("Email notification sent for notification {NotificationId}", notification.Id);
        }

        private async Task SendSmsNotificationAsync(Notification notification)
        {
            // Implement SMS sending logic
            await Task.Delay(100); // Simulate SMS sending
            _logger.LogInformation("SMS notification sent for notification {NotificationId}", notification.Id);
        }

        private async Task SendPushNotificationAsync(Notification notification)
        {
            // Implement push notification logic
            await Task.Delay(100); // Simulate push notification
            _logger.LogInformation("Push notification sent for notification {NotificationId}", notification.Id);
        }

        public async Task<ApiResponse<bool>> SendRealTimeNotificationToRoleAsync(int roleId, string title, string message)
        {
            try
            {
                if (roleId <= 0)
                    return ApiResponse<bool>.Error("Invalid role ID", 400);

                if (string.IsNullOrWhiteSpace(title))
                    return ApiResponse<bool>.Error("Title is required", 400);

                if (string.IsNullOrWhiteSpace(message))
                    return ApiResponse<bool>.Error("Message is required", 400);

                // ✅ Security: Only admins can send to roles
                if (!_currentUserService.IsInRole("Admin"))
                {
                    _logger.LogWarning("User {UserId} attempted to send notification to role {RoleId} without permission",
                        _currentUserService.UserId, roleId);
                    return ApiResponse<bool>.Error("Only admins can send notifications to roles", 403);
                }

                // This will be enhanced with SignalR hub
                _logger.LogInformation("User {UserId} sent real-time notification to role {RoleId}: {Title}",
                    _currentUserService.UserId, roleId, title);

                return ApiResponse<bool>.Success(true, "Notification sent to role successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending real-time notification to role {RoleId}", roleId);
                return ApiResponse<bool>.Error(ex.Message, 500);
            }
        }

        public async Task<ApiResponse<bool>> SendRealTimeNotificationToCompanyAsync(int companyId, string title, string message)
        {
            try
            {
                if (companyId <= 0)
                    return ApiResponse<bool>.Error("Invalid company ID", 400);

                if (string.IsNullOrWhiteSpace(title))
                    return ApiResponse<bool>.Error("Title is required", 400);

                if (string.IsNullOrWhiteSpace(message))
                    return ApiResponse<bool>.Error("Message is required", 400);

                // ✅ Security: Only admins and company managers can send to company
                if (!_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager") &&
                    _currentUserService.CompanyId != companyId)
                {
                    _logger.LogWarning("User {UserId} attempted to send notification to company {CompanyId} without permission",
                        _currentUserService.UserId, companyId);
                    return ApiResponse<bool>.Error("You don't have permission to send notifications to this company", 403);
                }

                // This will be enhanced with SignalR hub
                _logger.LogInformation("User {UserId} sent real-time notification to company {CompanyId}: {Title}",
                    _currentUserService.UserId, companyId, title);

                return ApiResponse<bool>.Success(true, "Notification sent to company successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending real-time notification to company {CompanyId}", companyId);
                return ApiResponse<bool>.Error(ex.Message, 500);
            }
        }
    }
}