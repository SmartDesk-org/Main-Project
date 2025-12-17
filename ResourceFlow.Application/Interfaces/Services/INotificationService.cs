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
        Task<ApiResponse<IEnumerable<NotificationDto>>> GetUserNotificationsAsync(int userId, bool unreadOnly = false);
        Task<ApiResponse<IEnumerable<NotificationDto>>> GetCompanyNotificationsAsync(int companyId, bool unreadOnly = false);
        Task<ApiResponse<IEnumerable<NotificationDto>>> GetRoleNotificationsAsync(int roleId, bool unreadOnly = false);

        // Mark as read
        Task<ApiResponse<bool>> MarkAsReadAsync(int notificationId);
        Task<ApiResponse<int>> MarkMultipleAsReadAsync(List<int> notificationIds);
        Task<ApiResponse<bool>> MarkAllAsReadAsync(int userId);

        // Real-time operations
        Task<ApiResponse<bool>> SendRealTimeNotificationAsync(int userId, string title, string message);
        Task<ApiResponse<bool>> SendRealTimeNotificationToRoleAsync(int roleId, string title, string message);
        Task<ApiResponse<bool>> SendRealTimeNotificationToCompanyAsync(int companyId, string title, string message);

        // Status operations
        Task<ApiResponse<int>> GetUnreadCountAsync(int userId);
        Task<ApiResponse<bool>> DeleteNotificationAsync(int notificationId);

        // System operations
        Task<ApiResponse<bool>> ProcessPendingNotificationsAsync();
        Task<ApiResponse<bool>> RetryFailedNotificationsAsync();
    }
}