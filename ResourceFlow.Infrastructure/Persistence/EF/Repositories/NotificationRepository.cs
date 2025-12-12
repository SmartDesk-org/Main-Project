using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<NotificationRepository> _logger;

        public NotificationRepository(AppDbContext context, ILogger<NotificationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CanSendNotificationAsync(int userId, NotificationType type, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);

                return user != null && user.IsActive && !user.IsBlocked;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if user {UserId} can receive notifications", userId);
                return false; // ✅ Safe default
            }
        }

        public async Task<string> GetUserNameAsync(int userId, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.UserId == userId)
                    .Select(u => u.UserName)
                    .FirstOrDefaultAsync(cancellationToken);

                return user ?? "Unknown User"; // ✅ Safe default
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting username for user {UserId}", userId);
                return "Unknown User"; // ✅ Safe default
            }
        }

        public async Task<string> GetCompanyNameAsync(int? companyId, CancellationToken cancellationToken = default)
        {
            if (!companyId.HasValue)
                return string.Empty;

            try
            {
                var company = await _context.CompanyDetails
                    .Where(c => c.CompanyId == companyId.Value)
                    .Select(c => c.Name)
                    .FirstOrDefaultAsync(cancellationToken);

                return company ?? "Unknown Company"; // ✅ Safe default
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting company name for company {CompanyId}", companyId);
                return "Unknown Company"; // ✅ Safe default
            }
        }

        public async Task<List<Notification>> GetUserNotificationsAsync(int userId, bool unreadOnly = false, CancellationToken cancellationToken = default)
        {
            try
            {
                var query = _context.Notifications
                    .Where(n => n.UserId == userId)
                    .AsNoTracking();

                if (unreadOnly)
                {
                    query = query.Where(n => !n.IsRead);
                }

                return await query
                    .OrderByDescending(n => n.CreatedAt)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user notifications for user {UserId}", userId);
                return new List<Notification>(); // ✅ Safe default
            }
        }

        public async Task<List<Notification>> GetCompanyNotificationsAsync(int companyId, bool unreadOnly = false, CancellationToken cancellationToken = default)
        {
            try
            {
                var query = _context.Notifications
                    .Where(n => n.CompanyId == companyId)
                    .AsNoTracking();

                if (unreadOnly)
                {
                    query = query.Where(n => !n.IsRead);
                }

                return await query
                    .OrderByDescending(n => n.CreatedAt)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting company notifications for company {CompanyId}", companyId);
                return new List<Notification>(); // ✅ Safe default
            }
        }

        public async Task<List<Notification>> GetRoleNotificationsAsync(int roleId, bool unreadOnly = false, CancellationToken cancellationToken = default)
        {
            try
            {
                var query = _context.Notifications
                    .Where(n => n.RoleId == roleId)
                    .AsNoTracking();

                if (unreadOnly)
                {
                    query = query.Where(n => !n.IsRead);
                }

                return await query
                    .OrderByDescending(n => n.CreatedAt)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting role notifications for role {RoleId}", roleId);
                return new List<Notification>(); // ✅ Safe default
            }
        }

        public async Task<List<Notification>> GetNotificationsByUserAndStatusAsync(int userId, bool isRead, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _context.Notifications
                    .Where(n => n.UserId == userId && n.IsRead == isRead)
                    .AsNoTracking()
                    .OrderByDescending(n => n.CreatedAt)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting notifications by status for user {UserId}", userId);
                return new List<Notification>(); // ✅ Safe default
            }
        }

        public async Task<int> GetUnreadCountForUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _context.Notifications
                    .CountAsync(n => n.UserId == userId && !n.IsRead, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unread count for user {UserId}", userId);
                return 0; // ✅ Safe default
            }
        }

        public async Task MarkMultipleAsReadAsync(List<int> notificationIds, int userId, CancellationToken cancellationToken = default)
        {
            try
            {
                var notifications = await _context.Notifications
                    .Where(n => notificationIds.Contains(n.Id) && n.UserId == userId && !n.IsRead)
                    .ToListAsync(cancellationToken);

                foreach (var notification in notifications)
                {
                    notification.IsRead = true;
                    notification.ReadAt = DateTime.UtcNow;
                    notification.Status = NotificationStatus.Read;
                    notification.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking multiple notifications as read for user {UserId}", userId);
                throw; // ✅ Re-throw for service layer handling
            }
        }

        public async Task MarkAllAsReadForUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            try
            {
                var notifications = await _context.Notifications
                    .Where(n => n.UserId == userId && !n.IsRead)
                    .ToListAsync(cancellationToken);

                foreach (var notification in notifications)
                {
                    notification.IsRead = true;
                    notification.ReadAt = DateTime.UtcNow;
                    notification.Status = NotificationStatus.Read;
                    notification.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking all notifications as read for user {UserId}", userId);
                throw; // ✅ Re-throw for service layer handling
            }
        }
    }
}