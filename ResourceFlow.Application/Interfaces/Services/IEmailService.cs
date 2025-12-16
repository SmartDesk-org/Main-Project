using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public  interface IEmailService
    {
        Task<bool> SendAsync(string to, string subject, string htmlBody);
        Task<bool> SendPasswordResetEmailAsync(string toEmail, string resetLink);
        Task<bool> SendWelcomeEmailAsync(string to);
    }
}
