using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Services;

public class EmployeeEmailService : IEmployeeEmailService
{
    private readonly IConfiguration _config;

    public EmployeeEmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendAsync(string to, string subject, string htmlBody)
    {
        var host = _config["Smtp:Host"];
        var port = int.Parse(_config["Smtp:Port"]);
        var username = _config["Smtp:Username"];
        var password = _config["Smtp:Password"];
        // Ensure this pulls the email address correctly
        var sender = _config["Smtp:SenderEmail"] ?? username;

        using var client = new SmtpClient(host, port)
        {
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(username, password),
            Timeout = 15000
        };

        var mail = new MailMessage
        {
            // CHANGE HERE: The second parameter is the "Display Name"
            From = new MailAddress(sender, "SmartDesk"),
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true
        };

        mail.To.Add(to);

        try
        {
            Console.WriteLine($"📧 Sending email to {to}...");
            await client.SendMailAsync(mail);
            Console.WriteLine($"✅ Email sent to {to}");
        }
        catch (SmtpException ex)
        {
            Console.WriteLine("❌ SMTP EXCEPTION");
            Console.WriteLine("Message: " + ex.Message);
            Console.WriteLine("StatusCode: " + ex.StatusCode);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ GENERAL EMAIL ERROR: " + ex.Message);
            throw;
        }
    }
}