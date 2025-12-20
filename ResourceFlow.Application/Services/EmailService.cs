using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
    public class EmailService:IEmailService
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
                var message = new MailMessage
                {
                    From = new MailAddress(smtp["SenderEmail"], "SmartDesk"),
                    Subject = "Reset Your SmartDesk Password",
                    Body = $@"
                        <div style='
                            font-family: Arial, sans-serif; 
                            max-width: 650px; 
                            margin: auto; 
                            padding: 0; 
                            background: linear-gradient(135deg, #e3f2fd, #fce4ec);
                            border-radius: 12px;
                            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
                        '>
                            <div style='
                                background: linear-gradient(135deg, #42a5f5, #ec407a);
                                padding: 25px; 
                                border-radius: 12px 12px 0 0; 
                                text-align: center;
                            '>
                                <h1 style='color: white; margin: 0; font-size: 26px;'>SmartDesk</h1>
                                <h3 style='color: #fefefe; margin-top: 10px;'>Password Reset Request</h3>
                            </div>

                            <div style='padding: 25px; background-color: rgba(255,255,255,0.85); border-radius: 0 0 12px 12px;'>
                                <p style='font-size: 15px; color: #333;'>Hello,</p>
                                <p style='font-size: 15px; color: #333;'>
                                    You requested to reset the password for your <strong>SmartDesk</strong> account.
                                </p>

                                <div style='text-align: center; margin: 35px 0;'>
                                    <a href='{resetLink}' 
                                       style='
                                           background: linear-gradient(135deg, #42a5f5, #7e57c2);
                                           color: #fff;
                                           padding: 14px 28px;
                                           text-decoration: none;
                                           border-radius: 30px;
                                           font-weight: bold;
                                           font-size: 16px;
                                           box-shadow: 0 4px 10px rgba(0,0,0,0.2);
                                       '>
                                        Reset Password
                                    </a>
                                </div>

                                <p style='font-size: 14px; color: #555;'>If the button above does not work, copy and paste this link:</p>

                                <p style='word-break: break-all;'>
                                    <a href='{resetLink}' style='color: #7e57c2; font-weight: bold;'>{resetLink}</a>
                                </p>

                                <p style='margin-top: 20px; font-size: 14px; color: #333;'>
                                    This link will expire shortly. If you did not request this password reset, you may safely ignore this email.
                                </p>

                                <p style='margin-top: 25px; font-size: 14px; color: #333;'>
                                    Regards,<br/>
                                    <strong>SmartDesk Team</strong>
                                </p>
                            </div>
                        </div>
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
        private async Task<bool> SendAsync(string to, string subject, string htmlBody, byte[]? attachment=null ,string? attachmentName=null)
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

                if(attachment != null)
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

            return await  SendAsync(
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
