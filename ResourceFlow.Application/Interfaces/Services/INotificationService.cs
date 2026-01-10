using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface INotificationService
    {
        // CRUD Operations
        Task<ApiResponse<NotificationDto>> CreateNotificationAsync(CreateNotificationDto createDto);
        Task<ApiResponse<NotificationDto>> GetNotificationByIdAsync(int id);

        // Current user operations
        Task<ApiResponse<IEnumerable<NotificationDto>>> GetMyNotificationsAsync(bool unreadOnly = false);
        Task<ApiResponse<int>> GetUnreadCountAsync(int userId);

        // Mark as read operations
        Task<ApiResponse<bool>> MarkAsReadAsync(int notificationId);
        Task<ApiResponse<int>> MarkMultipleAsReadAsync(List<int> notificationIds);
        Task<ApiResponse<bool>> MarkAllAsReadAsync(int userId);

        // Admin operations
        Task<ApiResponse<bool>> DeleteNotificationAsync(int notificationId);
        Task<ApiResponse<bool>> ProcessPendingNotificationsAsync();
        Task<ApiResponse<bool>> RetryFailedNotificationsAsync();
    }
}