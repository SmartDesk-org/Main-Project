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

    public async Task SendAsync(string to, string subject, string html)
    {
        var host = _config["Smtp:Host"];
        var port = int.Parse(_config["Smtp:Port"]);
        var user = _config["Smtp:Username"];
        var pass = _config["Smtp:Password"];

        using var client = new SmtpClient(host, port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(user, pass)
        };

        var mail = new MailMessage(user, to, subject, html)
        {
            IsBodyHtml = true
        };

        await client.SendMailAsync(mail);
    }
}
