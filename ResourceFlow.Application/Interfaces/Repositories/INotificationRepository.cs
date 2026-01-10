using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task<bool> CanSendNotificationAsync(int userId, NotificationType type, CancellationToken cancellationToken = default);
        Task<string> GetUserNameAsync(int userId, CancellationToken cancellationToken = default);
        Task<string> GetCompanyNameAsync(int? companyId, CancellationToken cancellationToken = default);

        // Current user notifications
        Task<List<Notification>> GetMyNotificationsAsync(
            int userId,
            int? roleId,
            int? companyId,
            bool unreadOnly,
            CancellationToken cancellationToken = default);

        Task<int> GetUnreadCountForUserAsync(int userId, CancellationToken cancellationToken = default);

        // Batch operations
        Task MarkMultipleAsReadAsync(List<int> notificationIds, int userId, CancellationToken cancellationToken = default);
        Task MarkAllAsReadForUserAsync(int userId, CancellationToken cancellationToken = default);

        Task<int?> GetUserCompanyIdAsync(int userId, CancellationToken cancellationToken = default);
    }
}