using ResourceFlow.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Services
{
    public class EmailService:IEmailService
    {
        public Task<bool> SendAsync(string to, string subject, string htmlBody)
        {
            // ========== DUMMY EMAIL SENDER ==========
            Console.WriteLine("==================================================");
            Console.WriteLine("📧 EMAIL SENDING (DUMMY SERVICE)");
            Console.WriteLine($"To      : {to}");
            Console.WriteLine($"Subject : {subject}");
            Console.WriteLine("Body:");
            Console.WriteLine(htmlBody);
            Console.WriteLine("==================================================");

            return Task.FromResult(true);
        }

        public Task<bool> SendPasswordResetEmailAsync(string to, string resetLink)
        {
            var body = $@"
                <h2>Password Reset Request</h2>
                <p>You requested to reset your password.</p>
                <p>Click the link below to reset it:</p>
                <a href=""{resetLink}"">{resetLink}</a>
                <br /><br />
                <p>If you did not request this, ignore this email.</p>
            ";

            return SendAsync(to, "Reset Your Password", body);
        }

        public Task<bool> SendWelcomeEmailAsync(string to)
        {
            var body = @"
                <h2>Welcome to ResourceFlow!</h2>
                <p>Your account has been created successfully.</p>
                <p>We’re excited to have you onboard.</p>
            ";

            return SendAsync(to, "Welcome to ResourceFlow!", body);
        }
    }
}
