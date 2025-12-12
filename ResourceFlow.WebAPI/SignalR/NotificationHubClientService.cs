using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ResourceFlow.WebAPI.Hubs;
using ResourceFlow.Application.Interfaces.Services;

namespace ResourceFlow.WebAPI.SignalR
{
  

    public class NotificationHubClientService : INotificationHubClientService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<NotificationHubClientService> _logger;

        public NotificationHubClientService(
            IHubContext<NotificationHub> hubContext,
            ILogger<NotificationHubClientService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task SendToUserAsync(int userId, string title, string message)
        {
            try
            {
                await _hubContext.Clients.User(userId.ToString())
                    .SendAsync("ReceiveNotification", title, message);

                _logger.LogInformation("SignalR notification sent to user {UserId}: {Title}", userId, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending SignalR notification to user {UserId}", userId);
                throw;
            }
        }

        public async Task SendToRoleAsync(int roleId, string title, string message)
        {
            try
            {
                await _hubContext.Clients.Group($"Role_{roleId}")
                    .SendAsync("ReceiveNotification", title, message);

                _logger.LogInformation("SignalR notification sent to role {RoleId}: {Title}", roleId, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending SignalR notification to role {RoleId}", roleId);
                throw;
            }
        }

        public async Task SendToCompanyAsync(int companyId, string title, string message)
        {
            try
            {
                await _hubContext.Clients.Group($"Company_{companyId}")
                    .SendAsync("ReceiveNotification", title, message);

                _logger.LogInformation("SignalR notification sent to company {CompanyId}: {Title}", companyId, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending SignalR notification to company {CompanyId}", companyId);
                throw;
            }
        }

        public async Task SendToAllAsync(string title, string message)
        {
            try
            {
                await _hubContext.Clients.All
                    .SendAsync("ReceiveNotification", title, message);

                _logger.LogInformation("SignalR notification sent to all users: {Title}", title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending SignalR notification to all users");
                throw;
            }
        }
    }
}