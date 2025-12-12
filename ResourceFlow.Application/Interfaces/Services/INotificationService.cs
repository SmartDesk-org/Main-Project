using ResourceFlow.Application.DTOs.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface INotificationService
    {
        // CRUD Operations
        Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto createDto);
        Task<NotificationDto> GetNotificationByIdAsync(int id);
        Task<IEnumerable<NotificationDto>> GetUserNotificationsAsync(int userId, bool unreadOnly = false);
        Task<IEnumerable<NotificationDto>> GetCompanyNotificationsAsync(int companyId, bool unreadOnly = false);
        Task<IEnumerable<NotificationDto>> GetRoleNotificationsAsync(int roleId, bool unreadOnly = false);

        // Mark as read
        Task<bool> MarkAsReadAsync(int notificationId);
        Task<int> MarkMultipleAsReadAsync(List<int> notificationIds);
        Task<bool> MarkAllAsReadAsync(int userId);

        // Real-time operations
        Task SendRealTimeNotificationAsync(int userId, string title, string message);
        Task SendRealTimeNotificationToRoleAsync(int roleId, string title, string message);
        Task SendRealTimeNotificationToCompanyAsync(int companyId, string title, string message);

        // Status operations
        Task<int> GetUnreadCountAsync(int userId);
        Task<bool> DeleteNotificationAsync(int notificationId);

        // System operations
        Task ProcessPendingNotificationsAsync();
        Task RetryFailedNotificationsAsync();
    }
}
