using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Notifications;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.WebAPI.SignalR;

namespace ResourceFlow.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] 
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly INotificationHubClientService _hubClientService;
        private readonly ILogger<NotificationsController> _logger;

        public NotificationsController(
            INotificationService notificationService,
            INotificationHubClientService hubClientService,
            ILogger<NotificationsController> logger)
        {
            _notificationService = notificationService;
            _hubClientService = hubClientService;
            _logger = logger;
        }

        /// <summary>
        /// Create a new notification
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<NotificationDto>>> CreateNotification(
            [FromBody] CreateNotificationDto createDto)
        {
            // ✅ ADDED: Model validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<NotificationDto>.Error(
                    "Invalid request data. Please check all required fields.",
                    400));
            }

            try
            {
                _logger.LogInformation("Creating notification with title: {Title}", createDto.Title);

                var notification = await _notificationService.CreateNotificationAsync(createDto);

                // Send real-time notification if requested
                if (createDto.SendImmediately && createDto.UserId.HasValue)
                {
                    await _hubClientService.SendToUserAsync(
                        createDto.UserId.Value,
                        createDto.Title,
                        createDto.Message);
                }

                return ApiResponse<NotificationDto>.Created(notification, "Notification created successfully");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to create notification");
                return Unauthorized(ApiResponse<NotificationDto>.Error(ex.Message, 403));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Invalid operation when creating notification");
                return BadRequest(ApiResponse<NotificationDto>.Error(ex.Message, 400));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating notification");
                return StatusCode(500, ApiResponse<NotificationDto>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Send real-time notification to user
        /// </summary>
        [HttpPost("realtime/user/{userId}")]
        [Authorize(Roles = "Admin,Manager")] // ✅ Added role authorization
        public async Task<ActionResult<ApiResponse<bool>>> SendRealTimeToUser(
            int userId,
            [FromBody] CreateNotificationDto createDto)
        {
            // ✅ ADDED: Model validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<bool>.Error("Invalid request data", 400));
            }

            try
            {
                _logger.LogInformation("Sending real-time notification to user {UserId}", userId);

                // Create and save notification
                createDto.UserId = userId;
                var notification = await _notificationService.CreateNotificationAsync(createDto);

                // Send via SignalR
                await _hubClientService.SendToUserAsync(userId, createDto.Title, createDto.Message);

                return ApiResponse<bool>.Success(true, "Real-time notification sent successfully");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to send real-time notification");
                return Unauthorized(ApiResponse<bool>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending real-time notification to user {UserId}", userId);
                return StatusCode(500, ApiResponse<bool>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Get notification by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<NotificationDto>>> GetNotification(int id)
        {
            try
            {
                var notification = await _notificationService.GetNotificationByIdAsync(id);

                if (notification == null)
                {
                    return NotFound(ApiResponse<NotificationDto>.Error("Notification not found"));
                }

                return ApiResponse<NotificationDto>.Success(notification);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to get notification {NotificationId}", id);
                return Unauthorized(ApiResponse<NotificationDto>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notification {NotificationId}", id);
                return StatusCode(500, ApiResponse<NotificationDto>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Get user notifications
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<NotificationDto>>>> GetUserNotifications(
            int userId,
            [FromQuery] bool unreadOnly = false)
        {
            try
            {
                var notifications = await _notificationService.GetUserNotificationsAsync(userId, unreadOnly);
                return ApiResponse<IEnumerable<NotificationDto>>.Success(notifications);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to get notifications for user {UserId}", userId);
                return Unauthorized(ApiResponse<IEnumerable<NotificationDto>>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for user {UserId}", userId);
                return StatusCode(500, ApiResponse<IEnumerable<NotificationDto>>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Get unread count for user
        /// </summary>
        [HttpGet("user/{userId}/unread-count")]
        public async Task<ActionResult<ApiResponse<int>>> GetUnreadCount(int userId)
        {
            try
            {
                var count = await _notificationService.GetUnreadCountAsync(userId);
                return ApiResponse<int>.Success(count);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to get unread count for user {UserId}", userId);
                return Unauthorized(ApiResponse<int>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unread count for user {UserId}", userId);
                return StatusCode(500, ApiResponse<int>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Mark notification as read
        /// </summary>
        [HttpPost("mark-read/{notificationId}")]
        public async Task<ActionResult<ApiResponse<bool>>> MarkAsRead(int notificationId)
        {
            try
            {
                var result = await _notificationService.MarkAsReadAsync(notificationId);

                if (!result)
                {
                    return NotFound(ApiResponse<bool>.Error("Notification not found"));
                }

                return ApiResponse<bool>.Success(true, "Notification marked as read");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to mark notification {NotificationId} as read", notificationId);
                return Unauthorized(ApiResponse<bool>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking notification {NotificationId} as read", notificationId);
                return StatusCode(500, ApiResponse<bool>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Mark multiple notifications as read
        /// </summary>
        [HttpPost("mark-multiple-read")]
        public async Task<ActionResult<ApiResponse<int>>> MarkMultipleAsRead(
            [FromBody] MarkMultipleNotificationsDto markDto)
        {
            try
            {
                if (markDto.NotificationIds == null || markDto.NotificationIds.Count == 0)
                {
                    return BadRequest(ApiResponse<int>.Error("At least one notification ID is required", 400));
                }

                var count = await _notificationService.MarkMultipleAsReadAsync(markDto.NotificationIds);
                return ApiResponse<int>.Success(count, $"{count} notifications marked as read");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to mark multiple notifications as read");
                return Unauthorized(ApiResponse<int>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking multiple notifications as read");
                return StatusCode(500, ApiResponse<int>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Mark all notifications as read for user
        /// </summary>
        [HttpPost("user/{userId}/mark-all-read")]
        public async Task<ActionResult<ApiResponse<bool>>> MarkAllAsRead(int userId)
        {
            try
            {
                var result = await _notificationService.MarkAllAsReadAsync(userId);
                return ApiResponse<bool>.Success(result, "All notifications marked as read");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to mark all notifications as read for user {UserId}", userId);
                return Unauthorized(ApiResponse<bool>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking all notifications as read for user {UserId}", userId);
                return StatusCode(500, ApiResponse<bool>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Delete notification
        /// </summary>
        [HttpDelete("{notificationId}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteNotification(int notificationId)
        {
            try
            {
                var result = await _notificationService.DeleteNotificationAsync(notificationId);

                if (!result)
                {
                    return NotFound(ApiResponse<bool>.Error("Notification not found"));
                }

                return ApiResponse<bool>.Success(true, "Notification deleted successfully");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to delete notification {NotificationId}", notificationId);
                return Unauthorized(ApiResponse<bool>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting notification {NotificationId}", notificationId);
                return StatusCode(500, ApiResponse<bool>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Get company notifications
        /// </summary>
        [HttpGet("company/{companyId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<NotificationDto>>>> GetCompanyNotifications(
            int companyId,
            [FromQuery] bool unreadOnly = false)
        {
            try
            {
                var notifications = await _notificationService.GetCompanyNotificationsAsync(companyId, unreadOnly);
                return ApiResponse<IEnumerable<NotificationDto>>.Success(notifications);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to get company {CompanyId} notifications", companyId);
                return Unauthorized(ApiResponse<IEnumerable<NotificationDto>>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for company {CompanyId}", companyId);
                return StatusCode(500, ApiResponse<IEnumerable<NotificationDto>>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Get role notifications
        /// </summary>
        [HttpGet("role/{roleId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<NotificationDto>>>> GetRoleNotifications(
            int roleId,
            [FromQuery] bool unreadOnly = false)
        {
            try
            {
                var notifications = await _notificationService.GetRoleNotificationsAsync(roleId, unreadOnly);
                return ApiResponse<IEnumerable<NotificationDto>>.Success(notifications);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt to get role {RoleId} notifications", roleId);
                return Unauthorized(ApiResponse<IEnumerable<NotificationDto>>.Error(ex.Message, 403));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for role {RoleId}", roleId);
                return StatusCode(500, ApiResponse<IEnumerable<NotificationDto>>.Error("Internal server error"));
            }
        }
    }
}