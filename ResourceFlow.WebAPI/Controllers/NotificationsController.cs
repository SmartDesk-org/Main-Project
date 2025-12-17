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
        public async Task<IActionResult> CreateNotification(
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

                var response = await _notificationService.CreateNotificationAsync(createDto);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                // Send real-time notification if requested
                if (createDto.SendImmediately && createDto.UserId.HasValue && response.Data != null)
                {
                    await _hubClientService.SendToUserAsync(
                        createDto.UserId.Value,
                        createDto.Title,
                        createDto.Message);
                }

                return StatusCode(response.StatusCode, response);
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
        public async Task<IActionResult> SendRealTimeToUser(
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
                var notificationResponse = await _notificationService.CreateNotificationAsync(createDto);

                if (notificationResponse.StatusCode >= 400)
                {
                    return StatusCode(notificationResponse.StatusCode, notificationResponse);
                }

                // Send via SignalR
                await _hubClientService.SendToUserAsync(userId, createDto.Title, createDto.Message);

                return Ok(ApiResponse<bool>.Success(true, "Real-time notification sent successfully"));
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
        public async Task<IActionResult> GetNotification(int id)
        {
            try
            {
                var response = await _notificationService.GetNotificationByIdAsync(id);

                if (response.StatusCode == 404)
                {
                    return NotFound(response);
                }

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
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
        public async Task<IActionResult> GetUserNotifications(
            int userId,
            [FromQuery] bool unreadOnly = false)
        {
            try
            {
                var response = await _notificationService.GetUserNotificationsAsync(userId, unreadOnly);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
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
        public async Task<IActionResult> GetUnreadCount(int userId)
        {
            try
            {
                var response = await _notificationService.GetUnreadCountAsync(userId);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
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
        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            try
            {
                var response = await _notificationService.MarkAsReadAsync(notificationId);

                if (response.StatusCode == 404)
                {
                    return NotFound(response);
                }

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
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
        public async Task<IActionResult> MarkMultipleAsRead(
            [FromBody] MarkMultipleNotificationsDto markDto)
        {
            try
            {
                if (markDto.NotificationIds == null || markDto.NotificationIds.Count == 0)
                {
                    return BadRequest(ApiResponse<int>.Error("At least one notification ID is required", 400));
                }

                var response = await _notificationService.MarkMultipleAsReadAsync(markDto.NotificationIds);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
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
        public async Task<IActionResult> MarkAllAsRead(int userId)
        {
            try
            {
                var response = await _notificationService.MarkAllAsReadAsync(userId);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
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
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            try
            {
                var response = await _notificationService.DeleteNotificationAsync(notificationId);

                if (response.StatusCode == 404)
                {
                    return NotFound(response);
                }

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
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
        public async Task<IActionResult> GetCompanyNotifications(
            int companyId,
            [FromQuery] bool unreadOnly = false)
        {
            try
            {
                var response = await _notificationService.GetCompanyNotificationsAsync(companyId, unreadOnly);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
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
        public async Task<IActionResult> GetRoleNotifications(
            int roleId,
            [FromQuery] bool unreadOnly = false)
        {
            try
            {
                var response = await _notificationService.GetRoleNotificationsAsync(roleId, unreadOnly);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications for role {RoleId}", roleId);
                return StatusCode(500, ApiResponse<IEnumerable<NotificationDto>>.Error("Internal server error"));
            }
        }
    }
}