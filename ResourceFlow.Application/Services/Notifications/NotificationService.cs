using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.DTOs.Notifications;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Enums;

namespace ResourceFlow.Application.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly IGenericRepository<Notification> _notificationGenericRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            IGenericRepository<Notification> notificationGenericRepository,
            INotificationRepository notificationRepository,
            ICurrentUserService currentUserService,
            IMapper mapper,
            ILogger<NotificationService> logger)
        {
            _notificationGenericRepository = notificationGenericRepository;
            _notificationRepository = notificationRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto createDto)
        {
            try
            {
                // ✅ Security: Validate current user is authenticated
                if (!_currentUserService.IsAuthenticated)
                {
                    _logger.LogWarning("Unauthenticated user attempted to create notification");
                    throw new UnauthorizedAccessException("User must be authenticated to create notifications");
                }

                // ✅ Security: If creating for specific user, check permissions
                if (createDto.UserId.HasValue && createDto.UserId.Value != _currentUserService.UserId)
                {
                    if (!_currentUserService.IsInRole("Admin") && !_currentUserService.IsInRole("Manager"))
                    {
                        _logger.LogWarning("User {CurrentUserId} attempted to create notification for user {TargetUserId} without permission",
                            _currentUserService.UserId, createDto.UserId.Value);
                        throw new UnauthorizedAccessException("You don't have permission to create notifications for other users");
                    }
                }

                _logger.LogInformation("User {UserId} creating notification for UserId: {TargetUserId}, Type: {Type}",
                    _currentUserService.UserId, createDto.UserId, createDto.NotificationType);

                // Validate notification context
                if (createDto.UserId.HasValue)
                {
                    var canSend = await _notificationRepository.CanSendNotificationAsync(
                        createDto.UserId.Value, createDto.NotificationType);

                    if (!canSend)
                    {
                        _logger.LogWarning("User {UserId} cannot receive notifications of type {Type}",
                            createDto.UserId, createDto.NotificationType);
                        throw new InvalidOperationException($"User cannot receive notifications of type {createDto.NotificationType}");
                    }
                }

                // ✅ Security: Sanitize inputs to prevent XSS
                createDto.Title = WebUtility.HtmlEncode(createDto.Title);
                createDto.Message = WebUtility.HtmlEncode(createDto.Message);

                var notification = _mapper.Map<Notification>(createDto);

                // Set additional properties
                notification.Status = NotificationStatus.Pending;
                notification.IsSent = false;
                notification.IsRead = false;
                notification.RetryCount = 0;
                notification.CreatedAt = DateTime.UtcNow;
                notification.CreatedBy = _currentUserService.UserId; // ✅ Track who created

                // Save to database
                await _notificationGenericRepository.AddAsync(notification);
                await _notificationGenericRepository.SaveChangesAsync();

                _logger.LogInformation("Notification {NotificationId} created successfully by user {UserId}",
                    notification.Id, _currentUserService.UserId);

                var notificationDto = _mapper.Map<NotificationDto>(notification);

                // ✅ ADDED: Null-safe enrichment
                if (createDto.UserId.HasValue)
                {
                    notificationDto.UserName = await _notificationRepository.GetUserNameAsync(createDto.UserId.Value) 
                                               ?? "Unknown User";
                }

                if (createDto.CompanyId.HasValue)
                {
                    notificationDto.CompanyName = await _notificationRepository.GetCompanyNameAsync(createDto.CompanyId.Value) 
                                                  ?? "Unknown Company";
                }

                return notificationDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating notification");
                throw;
            }
        }

        public async Task<NotificationDto> GetNotificationByIdAsync(int id)
        {
            try
            {
                var notification = await _notificationGenericRepository.GetByIdAsync(id);

                if (notification == null)
                {
                    _logger.LogWarning("Notification {NotificationId} not found", id);
                    return null; // ✅ Return null instead of throwing
                }

                // ✅ Security: Check if user has permission to view this notification
                if (notification.UserId.HasValue &&
                    notification.UserId.Value != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {UserId} attempted to access notification {NotificationId} belonging to user {OwnerUserId}",
                        _currentUserService.UserId, id, notification.UserId.Value);
                    throw new UnauthorizedAccessException("You don't have permission to view this notification");
                }

                var notificationDto = _mapper.Map<NotificationDto>(notification);

                // ✅ ADDED: Null-safe enrichment
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

                return notificationDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notification {NotificationId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<NotificationDto>> GetUserNotificationsAsync(int userId, bool unreadOnly = false)
        {
            try
            {
                // ✅ Security: Users can only view their own notifications (or admins/managers)
                if (userId != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {CurrentUserId} attempted to access notifications for user {TargetUserId}",
                        _currentUserService.UserId, userId);
                    throw new UnauthorizedAccessException("You don't have permission to view other users' notifications");
                }

                var notifications = await _notificationRepository
                    .GetUserNotificationsAsync(userId, unreadOnly);

                var notificationDtos = _mapper.Map<List<NotificationDto>>(notifications);

                // ✅ ADDED: Null-safe enrichment
                foreach (var dto in notificationDtos.Where(d => d.UserId.HasValue))
                {
                    dto.UserName = await _notificationRepository.GetUserNameAsync(dto.UserId.Value) 
                                   ?? "Unknown User";
                }

                return notificationDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for user {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<NotificationDto>> GetCompanyNotificationsAsync(int companyId, bool unreadOnly = false)
        {
            try
            {
                // ✅ Security: Check if user belongs to this company or is admin
                if (_currentUserService.CompanyId != companyId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {UserId} attempted to access company {CompanyId} notifications without permission",
                        _currentUserService.UserId, companyId);
                    throw new UnauthorizedAccessException("You don't have permission to view this company's notifications");
                }

                var notifications = await _notificationRepository
                    .GetCompanyNotificationsAsync(companyId, unreadOnly);

                var notificationDtos = _mapper.Map<List<NotificationDto>>(notifications);

                // ✅ ADDED: Null-safe enrichment for company name
                foreach (var dto in notificationDtos.Where(d => d.CompanyId.HasValue))
                {
                    dto.CompanyName = await _notificationRepository.GetCompanyNameAsync(dto.CompanyId.Value) 
                                      ?? "Unknown Company";
                }

                return notificationDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for company {CompanyId}", companyId);
                throw;
            }
        }

        public async Task<IEnumerable<NotificationDto>> GetRoleNotificationsAsync(int roleId, bool unreadOnly = false)
        {
            try
            {
                // ✅ Security: Users can only view their own role notifications (or admins)
                if (roleId != _currentUserService.RoleId && !_currentUserService.IsInRole("Admin"))
                {
                    _logger.LogWarning("User {UserId} with role {UserRoleId} attempted to access role {TargetRoleId} notifications",
                        _currentUserService.UserId, _currentUserService.RoleId, roleId);
                    throw new UnauthorizedAccessException("You don't have permission to view this role's notifications");
                }

                var notifications = await _notificationRepository
                    .GetRoleNotificationsAsync(roleId, unreadOnly);

                return _mapper.Map<List<NotificationDto>>(notifications);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for role {RoleId}", roleId);
                throw;
            }
        }

        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            try
            {
                var notification = await _notificationGenericRepository.GetByIdAsync(notificationId);

                if (notification == null)
                {
                    _logger.LogWarning("Notification {NotificationId} not found for marking as read", notificationId);
                    return false;
                }

                // ✅ Security: Check if notification belongs to current user
                if (notification.UserId.HasValue &&
                    notification.UserId.Value != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {UserId} attempted to mark notification {NotificationId} as read without permission",
                        _currentUserService.UserId, notificationId);
                    throw new UnauthorizedAccessException("You can only mark your own notifications as read");
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

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking notification {NotificationId} as read", notificationId);
                throw;
            }
        }

        public async Task<int> MarkMultipleAsReadAsync(List<int> notificationIds)
        {
            try
            {
                // ✅ FIXED: Get current user ID from authenticated context
                var currentUserId = _currentUserService.UserId;

                if (currentUserId == 0)
                {
                    throw new UnauthorizedAccessException("User must be authenticated to mark notifications as read");
                }

                // ✅ Security: Repository will only mark notifications belonging to this user
                await _notificationRepository.MarkMultipleAsReadAsync(notificationIds, currentUserId);

                _logger.LogInformation("User {UserId} marked {Count} notifications as read",
                    currentUserId, notificationIds.Count);
                return notificationIds.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking multiple notifications as read");
                throw;
            }
        }

        public async Task<bool> MarkAllAsReadAsync(int userId)
        {
            try
            {
                // ✅ Security: Users can only mark their own notifications as read
                if (userId != _currentUserService.UserId)
                {
                    _logger.LogWarning("User {CurrentUserId} attempted to mark all notifications as read for user {TargetUserId}",
                        _currentUserService.UserId, userId);
                    throw new UnauthorizedAccessException("You can only mark your own notifications as read");
                }

                await _notificationRepository.MarkAllAsReadForUserAsync(userId);

                _logger.LogInformation("User {UserId} marked all notifications as read", userId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking all notifications as read for user {UserId}", userId);
                throw;
            }
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            try
            {
                // ✅ Security: Users can only get their own unread count
                if (userId != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {CurrentUserId} attempted to get unread count for user {TargetUserId}",
                        _currentUserService.UserId, userId);
                    throw new UnauthorizedAccessException("You can only get your own unread count");
                }

                return await _notificationRepository.GetUnreadCountForUserAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unread count for user {UserId}", userId);
                throw;
            }
        }

        public async Task SendRealTimeNotificationAsync(int userId, string title, string message)
        {
            try
            {
                // ✅ Security: Only admins and managers can send real-time notifications
                if (!_currentUserService.IsInRole("Admin") && !_currentUserService.IsInRole("Manager"))
                {
                    _logger.LogWarning("User {UserId} attempted to send real-time notification without permission",
                        _currentUserService.UserId);
                    throw new UnauthorizedAccessException("Only admins and managers can send real-time notifications");
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

                await CreateNotificationAsync(createDto);

                _logger.LogInformation("User {UserId} sent real-time notification to user {TargetUserId}",
                    _currentUserService.UserId, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending real-time notification to user {UserId}", userId);
                throw;
            }
        }

        public async Task<bool> DeleteNotificationAsync(int notificationId)
        {
            try
            {
                var notification = await _notificationGenericRepository.GetByIdAsync(notificationId);

                if (notification == null)
                {
                    _logger.LogWarning("Notification {NotificationId} not found for deletion", notificationId);
                    return false;
                }

                // ✅ Security: Only admins or notification owners can delete
                if (notification.CreatedBy != _currentUserService.UserId &&
                    !_currentUserService.IsInRole("Admin"))
                {
                    _logger.LogWarning("User {UserId} attempted to delete notification {NotificationId} created by user {CreatorUserId}",
                        _currentUserService.UserId, notificationId, notification.CreatedBy);
                    throw new UnauthorizedAccessException("You don't have permission to delete this notification");
                }

                await _notificationGenericRepository.DeleteAsync(notification);
                await _notificationGenericRepository.SaveChangesAsync();

                _logger.LogInformation("Notification {NotificationId} deleted successfully by user {UserId}",
                    notificationId, _currentUserService.UserId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting notification {NotificationId}", notificationId);
                throw;
            }
        }

        public async Task ProcessPendingNotificationsAsync()
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing pending notifications");
                throw;
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

        public async Task RetryFailedNotificationsAsync()
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrying failed notifications");
                throw;
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

        public Task SendRealTimeNotificationToRoleAsync(int roleId, string title, string message)
        {
            try
            {
                // ✅ Security: Only admins can send to roles
                if (!_currentUserService.IsInRole("Admin"))
                {
                    _logger.LogWarning("User {UserId} attempted to send notification to role {RoleId} without permission",
                        _currentUserService.UserId, roleId);
                    throw new UnauthorizedAccessException("Only admins can send notifications to roles");
                }

                // This will be enhanced with SignalR hub
                _logger.LogInformation("User {UserId} sent real-time notification to role {RoleId}: {Title}",
                    _currentUserService.UserId, roleId, title);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending real-time notification to role {RoleId}", roleId);
                throw;
            }
        }

        public Task SendRealTimeNotificationToCompanyAsync(int companyId, string title, string message)
        {
            try
            {
                // ✅ Security: Only admins and company managers can send to company
                if (!_currentUserService.IsInRole("Admin") &&
                    !_currentUserService.IsInRole("Manager") &&
                    _currentUserService.CompanyId != companyId)
                {
                    _logger.LogWarning("User {UserId} attempted to send notification to company {CompanyId} without permission",
                        _currentUserService.UserId, companyId);
                    throw new UnauthorizedAccessException("You don't have permission to send notifications to this company");
                }

                // This will be enhanced with SignalR hub
                _logger.LogInformation("User {UserId} sent real-time notification to company {CompanyId}: {Title}",
                    _currentUserService.UserId, companyId, title);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending real-time notification to company {CompanyId}", companyId);
                throw;
            }
        }
    }
}