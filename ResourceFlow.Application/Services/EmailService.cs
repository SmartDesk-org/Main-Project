using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ResourceFlow.Application.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendPasswordResetEmailAsync(string toEmail, string resetLink)
        {
            var smtp = _config.GetSection("SmtpSettings");

            try
            {
                using var client = new SmtpClient
                {
                    Host = smtp["Host"],
                    Port = int.Parse(smtp["Port"]),
                    EnableSsl = true,
                    Credentials = new NetworkCredential(
                        smtp["Username"],
                        smtp["Password"]
                    )
                };

                var message = new MailMessage
                {
                    From = new MailAddress(smtp["SenderEmail"], "ResourceFlow"),
                    Subject = "Password Reset Request",
                    Body = $@"
                        <h2>Password Reset Request</h2>
                        <p>Click the link below to reset your password:</p>
                        <p><a href=""{resetLink}"">{resetLink}</a></p>
                        <p>This link is valid for a limited time.</p>
                    ",
                    IsBodyHtml = true
                };

                message.To.Add(toEmail);

                await client.SendMailAsync(message);
                return true;
            }
            catch
            {
                // For development only, print the link if email fails
                Console.WriteLine("Email sending failed. Reset link:");
                Console.WriteLine(resetLink);
                return false;
            }
        }
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
