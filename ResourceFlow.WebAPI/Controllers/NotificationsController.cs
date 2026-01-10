using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Notifications;
using ResourceFlow.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceFlow.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<NotificationsController> _logger;

        public NotificationsController(
            INotificationService notificationService,
            ILogger<NotificationsController> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        /// <summary>
        /// Create a new notification
        /// </summary>
        [HttpPost]
        //[Authorize(Roles = "SuperAdmin,CompanyAdmin")]
        public async Task<IActionResult> CreateNotification(
          [FromBody] CreateNotificationDto createDto)
        {
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

                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating notification");
                return StatusCode(500, ApiResponse<NotificationDto>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Get notification by ID
        /// </summary>
        [HttpGet("{id}")]
        //[Authorize]
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
        /// Get notifications for current user (User + Role + Company + Global)
        /// </summary>
        [HttpGet("my")]
        //[Authorize]
        public async Task<IActionResult> GetMyNotifications(
            [FromQuery] bool unreadOnly = false)
        {
            try
            {
                var response = await _notificationService.GetMyNotificationsAsync(unreadOnly);

                if (response.StatusCode >= 400)
                    return StatusCode(response.StatusCode, response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting current user notifications");
                return StatusCode(500,
                    ApiResponse<IEnumerable<NotificationDto>>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Get unread count for current user
        /// </summary>
        [HttpGet("my/unread-count")]
        //[Authorize]
        public async Task<IActionResult> GetMyUnreadCount()
        {
            try
            {
                var currentUserId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
                if (currentUserId <= 0)
                {
                    return Unauthorized(ApiResponse<int>.Error("User not authenticated", 401));
                }

                var response = await _notificationService.GetUnreadCountAsync(currentUserId);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unread count for current user");
                return StatusCode(500, ApiResponse<int>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Mark notification as read
        /// </summary>
        [HttpPost("mark-read/{notificationId}")]
        //[Authorize]
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
        //[HttpPost("mark-multiple-read")]
        ////[Authorize]
        //public async Task<IActionResult> MarkMultipleAsRead(
        //    [FromBody] MarkMultipleNotificationsDto markDto)
        //{
        //    try
        //    {
        //        if (markDto.NotificationIds == null || markDto.NotificationIds.Count == 0)
        //        {
        //            return BadRequest(ApiResponse<int>.Error("At least one notification ID is required", 400));
        //        }

        //        var response = await _notificationService.MarkMultipleAsReadAsync(markDto.NotificationIds);

        //        if (response.StatusCode >= 400)
        //        {
        //            return StatusCode(response.StatusCode, response);
        //        }

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error marking multiple notifications as read");
        //        return StatusCode(500, ApiResponse<int>.Error("Internal server error"));
        //    }
        //}

        /// <summary>
        /// Mark all notifications as read for current user
        /// </summary>
        [HttpPost("my/mark-all-read")]
        //[Authorize]
        public async Task<IActionResult> MarkAllAsRead()
        {
            try
            {
                var currentUserId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
                if (currentUserId <= 0)
                {
                    return Unauthorized(ApiResponse<bool>.Error("User not authenticated", 401));
                }

                var response = await _notificationService.MarkAllAsReadAsync(currentUserId);

                if (response.StatusCode >= 400)
                {
                    return StatusCode(response.StatusCode, response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking all notifications as read for current user");
                return StatusCode(500, ApiResponse<bool>.Error("Internal server error"));
            }
        }

        /// <summary>
        /// Delete notification
        /// </summary>
        [HttpDelete("{notificationId}")]
        //[Authorize(Roles = "SuperAdmin,CompanyAdmin")]
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
        /// Process pending notifications (Admin only)
        ///// </summary>
        //[HttpPost("process-pending")]
        ////[Authorize(Roles = "SuperAdmin")]
        //public async Task<IActionResult> ProcessPendingNotifications()
        //{
        //    try
        //    {
        //        var response = await _notificationService.ProcessPendingNotificationsAsync();

        //        if (response.StatusCode >= 400)
        //        {
        //            return StatusCode(response.StatusCode, response);
        //        }

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error processing pending notifications");
        //        return StatusCode(500, ApiResponse<bool>.Error("Internal server error"));
        //    }
        //}

        /// <summary>
        /// Retry failed notifications (Admin only)
        /// </summary>
        //[HttpPost("retry-failed")]
        ////[Authorize(Roles = "SuperAdmin")]
        //public async Task<IActionResult> RetryFailedNotifications()
        //{
        //    try
        //    {
        //        var response = await _notificationService.RetryFailedNotificationsAsync();

        //        if (response.StatusCode >= 400)
        //        {
        //            return StatusCode(response.StatusCode, response);
        //        }

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error retrying failed notifications");
        //        return StatusCode(500, ApiResponse<bool>.Error("Internal server error"));
        //    }
        //}
    }
}