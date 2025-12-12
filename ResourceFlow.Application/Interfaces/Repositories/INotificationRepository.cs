using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task<bool> CanSendNotificationAsync(int userId, NotificationType type, CancellationToken cancellationToken = default);
        Task<string> GetUserNameAsync(int userId, CancellationToken cancellationToken = default);
        Task<string> GetCompanyNameAsync(int? companyId, CancellationToken cancellationToken = default);

        // Updated with cancellation token and better filtering
        Task<List<Notification>> GetUserNotificationsAsync(int userId, bool unreadOnly = false, CancellationToken cancellationToken = default);
        Task<List<Notification>> GetCompanyNotificationsAsync(int companyId, bool unreadOnly = false, CancellationToken cancellationToken = default);
        Task<List<Notification>> GetRoleNotificationsAsync(int roleId, bool unreadOnly = false, CancellationToken cancellationToken = default);

        Task<List<Notification>> GetNotificationsByUserAndStatusAsync(int userId, bool isRead, CancellationToken cancellationToken = default);
        Task<int> GetUnreadCountForUserAsync(int userId, CancellationToken cancellationToken = default);

        // Batch operations
        Task MarkMultipleAsReadAsync(List<int> notificationIds, int userId, CancellationToken cancellationToken = default);
        Task MarkAllAsReadForUserAsync(int userId, CancellationToken cancellationToken = default);
    }

}