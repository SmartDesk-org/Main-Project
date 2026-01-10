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
        private readonly INotificationHubClientService _hubClientService;

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
                    "User {UserId} (Role: {RoleId}) creating notification. Title: {Title}",
                    _currentUserService.UserId,
                    _currentUserService.RoleId,
                    createDto.Title);

               
                // Only SuperAdmin and CompanyAdmin can create notifications
                //if (!_currentUserService.IsInRole("SuperAdmin") && !_currentUserService.IsInRole("CompanyAdmin"))
                //{
                //    return ApiResponse<NotificationDto>.Error(
                //        "Only SuperAdmin and CompanyAdmin can create notifications", 403);
                //}

                // ✅ CompanyAdmin can only create notifications for their own company
                //if (_currentUserService.IsInRole("CompanyAdmin"))
                //{
                //    if (createDto.CompanyId.HasValue && createDto.CompanyId.Value != _currentUserService.CompanyId)
                //    {
                //        return ApiResponse<NotificationDto>.Error(
                //            "CompanyAdmin can only create notifications for their own company", 403);
                //    }

                    // Force CompanyAdmin notifications to be for their company
                //    if (!createDto.CompanyId.HasValue || createDto.CompanyId.Value == 0)
                //    {
                //        createDto.CompanyId = _currentUserService.CompanyId;
                //    }
                //}

                // ✅ SuperAdmin can create for any company
                // No restrictions for SuperAdmin

                // 🔹 Determine NotificationType
                NotificationType tempType = createDto.NotificationType;

                if (tempType == 0)
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

                if ((createDto.CompanyId == 0 || createDto.CompanyId == null) &&
                    (createDto.UserId == 0 || createDto.UserId == null) &&
                    (createDto.RoleId == 0 || createDto.RoleId == null))
                {
                    isForAllUsers = true;
                    _logger.LogInformation("Sending notification to all users: {Title}", createDto.Title);
                }
                else
                {
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
                        await _hubClientService.SendToAllAsync(notification.Title, notification.Message);
                        _logger.LogInformation("Notification sent to all users via SignalR: {Title}", notification.Title);
                    }
                    else if (notification.UserId.HasValue)
                    {
                        await _hubClientService.SendToUserAsync(
                            notification.UserId.Value,
                            notification.Title,
                            notification.Message);
                    }
                    else if (notification.RoleId.HasValue)
                    {
                        await _hubClientService.SendToRoleAsync(
                            notification.RoleId.Value,
                            notification.Title,
                            notification.Message);
                    }
                    else if (notification.CompanyId.HasValue)
                    {
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

               
                // 1. SuperAdmin can access ANY notification
                //if (_currentUserService.IsInRole("SuperAdmin"))
                //{
                //    // No restrictions - SuperAdmin can access all
                //}
                //// 2. CompanyAdmin can access their company notifications
                //else if (_currentUserService.IsInRole("CompanyAdmin"))
                //{
                //    if (notification.CompanyId.HasValue && notification.CompanyId.Value != _currentUserService.CompanyId)
                //    {
                //        _logger.LogWarning("CompanyAdmin {UserId} attempted to access notification from different company",
                //            _currentUserService.UserId);
                //        return ApiResponse<NotificationDto>.Error("You can only access your own company's notifications", 403);
                //    }
                //}
                //// 3. Employee can access their own notifications or company notifications
                //else
                //{
                //    // Check if notification belongs to user
                //    if (notification.UserId.HasValue && notification.UserId.Value != _currentUserService.UserId)
                //    {
                //        // Check if notification belongs to same company
                //        if (!notification.CompanyId.HasValue ||
                //            notification.CompanyId.Value != _currentUserService.CompanyId)
                //        {
                //            _logger.LogWarning("Employee {UserId} attempted to access notification {NotificationId}",
                //                _currentUserService.UserId, id);
                //            return ApiResponse<NotificationDto>.Error("You don't have permission to view this notification", 403);
                //        }
                //    }
                //}

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

        public async Task<ApiResponse<IEnumerable<NotificationDto>>> GetMyNotificationsAsync(bool unreadOnly = false)
        {
            try
            {
                var userId = _currentUserService.UserId;
                var roleId = _currentUserService.RoleId;
                var companyId = _currentUserService.CompanyId;

                //if (userId <= 0)
                //    return ApiResponse<IEnumerable<NotificationDto>>.Error("User not authenticated", 401);

                var notifications = await _notificationRepository
                    .GetMyNotificationsAsync(userId, roleId, companyId, unreadOnly);

                var notificationDtos = _mapper.Map<List<NotificationDto>>(notifications);

                // 🔹 Enrichment
                foreach (var dto in notificationDtos)
                {
                    if (dto.UserId.HasValue)
                    {
                        dto.UserName =
                            await _notificationRepository.GetUserNameAsync(dto.UserId.Value)
                            ?? "Unknown User";
                    }

                    if (dto.CompanyId.HasValue)
                    {
                        dto.CompanyName =
                            await _notificationRepository.GetCompanyNameAsync(dto.CompanyId.Value)
                            ?? "Unknown Company";
                    }
                }

                return ApiResponse<IEnumerable<NotificationDto>>.Success(
                    notificationDtos,
                    $"Retrieved {notificationDtos.Count} notification(s)");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting combined notifications for current user");
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

               
                // Users can mark their own notifications as read
                //if (notification.UserId.HasValue && notification.UserId.Value != _currentUserService.UserId)
                //{
                //    // SuperAdmin and CompanyAdmin can mark any notification as read
                //    if (!_currentUserService.IsInRole("SuperAdmin") && !_currentUserService.IsInRole("CompanyAdmin"))
                //    {
                //        _logger.LogWarning("User {UserId} attempted to mark notification {NotificationId} as read without permission",
                //            _currentUserService.UserId, notificationId);
                //        return ApiResponse<bool>.Error("You can only mark your own notifications as read", 403);
                //    }
                //}

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

                var currentUserId = _currentUserService.UserId;

                if (currentUserId == 0)
                {
                    return ApiResponse<int>.Error("User must be authenticated to mark notifications as read", 401);
                }

                // ✅ Repository handles ownership check internally
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

                // Users can mark all their own notifications as read
                if (userId != _currentUserService.UserId)
                {
                    // SuperAdmin and CompanyAdmin can mark all for users in their company
                    if (_currentUserService.IsInRole("SuperAdmin"))
                    {
                        // SuperAdmin can mark all for any user
                    }
                    else if (_currentUserService.IsInRole("CompanyAdmin"))
                    {
                        var userCompany = await _notificationRepository.GetUserCompanyIdAsync(userId);
                        if (userCompany != _currentUserService.CompanyId)
                        {
                            _logger.LogWarning("CompanyAdmin {CurrentUserId} attempted to mark all for user {TargetUserId} from different company",
                                _currentUserService.UserId, userId);
                            return ApiResponse<bool>.Error("You can only mark notifications for users in your company", 403);
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Employee {CurrentUserId} attempted to mark all notifications as read for user {TargetUserId}",
                            _currentUserService.UserId, userId);
                        return ApiResponse<bool>.Error("You can only mark your own notifications as read", 403);
                    }
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

                // ✅ INDUSTRY-LEVEL PERMISSION CHECK
                // Users can get their own unread count
                if (userId != _currentUserService.UserId)
                {
                    // SuperAdmin can get any user's unread count
                    if (_currentUserService.IsInRole("SuperAdmin"))
                    {
                        // No restrictions
                    }
                    // CompanyAdmin can get unread count for users in their company
                    else if (_currentUserService.IsInRole("CompanyAdmin"))
                    {
                        var userCompany = await _notificationRepository.GetUserCompanyIdAsync(userId);
                        if (userCompany != _currentUserService.CompanyId)
                        {
                            _logger.LogWarning("CompanyAdmin {CurrentUserId} attempted to get unread count for user {TargetUserId}",
                                _currentUserService.UserId, userId);
                            return ApiResponse<int>.Error("You can only get unread count for users in your company", 403);
                        }
                    }
                    // Employee cannot get others' unread count
                    else
                    {
                        _logger.LogWarning("Employee {CurrentUserId} attempted to get unread count for user {TargetUserId}",
                            _currentUserService.UserId, userId);
                        return ApiResponse<int>.Error("You can only get your own unread count", 403);
                    }
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

               
                // Only SuperAdmin and CompanyAdmin can delete notifications
                //if (!_currentUserService.IsInRole("SuperAdmin") && !_currentUserService.IsInRole("CompanyAdmin"))
                //{
                //    _logger.LogWarning("User {UserId} attempted to delete notification {NotificationId} without permission",
                //        _currentUserService.UserId, notificationId);
                //    return ApiResponse<bool>.Error("Only SuperAdmin and CompanyAdmin can delete notifications", 403);
                //}

                //// ✅ CompanyAdmin can only delete notifications from their company
                //if (_currentUserService.IsInRole("CompanyAdmin"))
                //{
                //    if (!notification.CompanyId.HasValue || notification.CompanyId.Value != _currentUserService.CompanyId)
                //    {
                //        _logger.LogWarning("CompanyAdmin {UserId} attempted to delete notification {NotificationId} from different company",
                //            _currentUserService.UserId, notificationId);
                //        return ApiResponse<bool>.Error("You can only delete notifications from your own company", 403);
                //    }
                //}

                // ✅ SuperAdmin can delete any notification (no restrictions)

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
                _logger.LogInformation("Starting to process pending notifications");

                var queryable = _notificationGenericRepository.GetQueryable();

                var pendingNotifications = queryable
                    .Where(n => n.Status == NotificationStatus.Pending &&
                               n.TargetChannel != TargetChannel.InApp)
                    .ToList();

                // ✅ FIXED: Add await before ProcessNotifications
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
                        default:
                            _logger.LogWarning("Unknown target channel {Channel} for notification {NotificationId}",
                                notification.TargetChannel, notification.Id);
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
                _logger.LogInformation("Starting to retry failed notifications");

                var queryable = _notificationGenericRepository.GetQueryable();

                var failedNotifications = queryable
                    .Where(n => n.Status == NotificationStatus.Failed && n.RetryCount < 3)
                    .ToList();

                // ✅ FIXED: Add await before RetryNotifications
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

            // ✅ FIXED: Add await before ProcessPendingNotificationsAsync
            await ProcessPendingNotificationsAsync();
        }

        private async Task SendEmailNotificationAsync(Notification notification)
        {
            // Implement email sending logic
            await Task.Delay(100);
            _logger.LogInformation("Email notification sent for notification {NotificationId}", notification.Id);
        }

        private async Task SendSmsNotificationAsync(Notification notification)
        {
            // Implement SMS sending logic
            await Task.Delay(100);
            _logger.LogInformation("SMS notification sent for notification {NotificationId}", notification.Id);
        }

        private async Task SendPushNotificationAsync(Notification notification)
        {
            // Implement push notification logic
            await Task.Delay(100);
            _logger.LogInformation("Push notification sent for notification {NotificationId}", notification.Id);
        }
    }
}