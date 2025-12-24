using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ResourceFlow.Application.EmailTemplates;
using ResourceFlow.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendPasswordResetEmailAsync(string toEmail, string resetLink)
        {
            var smtp = _config.GetSection("Smtp");

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
                var htmlBody = PasswordResetEmailTemplate.Build(resetLink);
                var message = new MailMessage

                {
                    From = new MailAddress(smtp["SenderEmail"], "SmartDesk"),
                    Subject = "Reset Your SmartDesk Password",
                    Body = htmlBody,
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
        private async Task<bool> SendAsync(string to, string subject, string htmlBody, byte[]? attachment = null, string? attachmentName = null)
        {
            // ========== Generic  EMAIL SENDER ==========
            Console.WriteLine("==================================================");
            Console.WriteLine("📧 EMAIL SENDING (DUMMY SERVICE)");
            Console.WriteLine($"To      : {to}");
            Console.WriteLine($"Subject : {subject}");
            Console.WriteLine("Body:");
            Console.WriteLine(htmlBody);
            Console.WriteLine("==================================================");

            var smtp = _config.GetSection("smtp");
            try
            {
                using var client = new SmtpClient
                {
                    Host = smtp["Host"],
                    Port = int.Parse(smtp["Port"]),
                    EnableSsl = true,
                    Credentials = new NetworkCredential
                    {
                        UserName = smtp["Username"],
                        Password = smtp["Password"]
                    }
                };

                var message = new MailMessage
                {
                    From = new MailAddress(smtp["SenderEmail"], "SmartDesk"),
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };

                message.To.Add(to);

                if (attachment != null)
                {
                    message.Attachments.Add(
                        new Attachment(
                            new MemoryStream(attachment),
                            attachmentName ?? "bill.pdf",
                            "application/pdf"
                            )
                        );
                }

                await client.SendMailAsync(message);
                return true;
            }
            catch
            {
                Console.WriteLine("failed sending mail");
                return false;
            }

        }



        public async Task<bool> SendBillAsync(string toMail, byte[] pdf)
        {
            var body = $@"
                        <h1>Smart Desk<h1>
                         <h3>Your Purchase Bill</h3>
                        <p>Please find your bill attached.</p>
                        <p>Thank you for your purchase.</p>
                        ";

            return await SendAsync(
                toMail,
                "Your Purcahse Bill",
                body,
                pdf,
                "bill.pdf"
                );
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
