using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface INotificationHubClientService
    {
        Task SendToUserAsync(int userId, string title, string message);
        Task SendToRoleAsync(int roleId, string title, string message);
        Task SendToCompanyAsync(int companyId, string title, string message);
        Task SendToAllAsync(string title, string message);
    }
}
