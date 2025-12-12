using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Interfaces.Services;

namespace ResourceFlow.WebAPI.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        private readonly ILogger<NotificationHub> _logger;
        private readonly INotificationService _notificationService;
        private static readonly ConnectionMapping<string> _connections = new ConnectionMapping<string>();

        public NotificationHub(
            ILogger<NotificationHub> logger,
            INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }

        public override async Task OnConnectedAsync()
        {
            try
            {
                var userId = Context.UserIdentifier;

                if (!string.IsNullOrEmpty(userId))
                {
                    _connections.Add(userId, Context.ConnectionId);
                    _logger.LogInformation("User {UserId} connected with connection {ConnectionId}",
                        userId, Context.ConnectionId);

                    // Send unread count to the user
                    if (int.TryParse(userId, out int userIdInt))
                    {
                        var unreadCount = await _notificationService.GetUnreadCountAsync(userIdInt);
                        await Clients.Caller.SendAsync("ReceiveUnreadCount", unreadCount);
                    }
                }

                await base.OnConnectedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in OnConnectedAsync");
                throw;
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                var userId = Context.UserIdentifier;

                if (!string.IsNullOrEmpty(userId))
                {
                    _connections.Remove(userId, Context.ConnectionId);
                    _logger.LogInformation("User {UserId} disconnected", userId);
                }

                await base.OnDisconnectedAsync(exception);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in OnDisconnectedAsync");
                throw;
            }
        }

        // Send notification to specific user
        public async Task SendToUser(string userId, string title, string message)
        {
            try
            {
                var connections = _connections.GetConnections(userId);

                if (connections != null)
                {
                    foreach (var connectionId in connections)
                    {
                        await Clients.Client(connectionId).SendAsync("ReceiveNotification", title, message);
                    }

                    _logger.LogInformation("Notification sent to user {UserId}: {Title}", userId, title);
                }
                else
                {
                    _logger.LogWarning("User {UserId} is not connected", userId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending notification to user {UserId}", userId);
                throw;
            }
        }

        // Send notification to all users in a role
        public async Task SendToRole(int roleId, string title, string message)
        {
            try
            {
                await Clients.Group($"Role_{roleId}").SendAsync("ReceiveNotification", title, message);
                _logger.LogInformation("Notification sent to role {RoleId}: {Title}", roleId, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending notification to role {RoleId}", roleId);
                throw;
            }
        }

        // Send notification to all users in a company
        public async Task SendToCompany(int companyId, string title, string message)
        {
            try
            {
                await Clients.Group($"Company_{companyId}").SendAsync("ReceiveNotification", title, message);
                _logger.LogInformation("Notification sent to company {CompanyId}: {Title}", companyId, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending notification to company {CompanyId}", companyId);
                throw;
            }
        }

        // User joins role group
        public async Task JoinRoleGroup(int roleId)
        {
            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"Role_{roleId}");
                _logger.LogInformation("User {UserId} joined role group {RoleId}",
                    Context.UserIdentifier, roleId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error joining role group {RoleId}", roleId);
                throw;
            }
        }

        // User joins company group
        public async Task JoinCompanyGroup(int companyId)
        {
            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"Company_{companyId}");
                _logger.LogInformation("User {UserId} joined company group {CompanyId}",
                    Context.UserIdentifier, companyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error joining company group {CompanyId}", companyId);
                throw;
            }
        }

        // Leave role group
        public async Task LeaveRoleGroup(int roleId)
        {
            try
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Role_{roleId}");
                _logger.LogInformation("User {UserId} left role group {RoleId}",
                    Context.UserIdentifier, roleId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error leaving role group {RoleId}", roleId);
                throw;
            }
        }

        // Leave company group
        public async Task LeaveCompanyGroup(int companyId)
        {
            try
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Company_{companyId}");
                _logger.LogInformation("User {UserId} left company group {CompanyId}",
                    Context.UserIdentifier, companyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error leaving company group {CompanyId}", companyId);
                throw;
            }
        }
    }

    // Connection mapping for tracking user connections
    public class ConnectionMapping<T>
    {
        private readonly Dictionary<T, HashSet<string>> _connections = new Dictionary<T, HashSet<string>>();

        public void Add(T key, string connectionId)
        {
            lock (_connections)
            {
                if (!_connections.TryGetValue(key, out var connections))
                {
                    connections = new HashSet<string>();
                    _connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(T key)
        {
            if (_connections.TryGetValue(key, out var connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public void Remove(T key, string connectionId)
        {
            lock (_connections)
            {
                if (!_connections.TryGetValue(key, out var connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        _connections.Remove(key);
                    }
                }
            }
        }
    }
}