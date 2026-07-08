using System.Net;
using System.Net.Mail;

namespace Portfolio.Services;

public sealed class SmtpEmailSender : IEmailSender
{
    private readonly IConfiguration _config;
    private readonly ILogger<SmtpEmailSender> _logger;

    public SmtpEmailSender(IConfiguration config, ILogger<SmtpEmailSender> logger)
    {
        _config = config;
        _logger = logger;
    }

    public async Task SendContactMessageAsync(string name, string email, string message, CancellationToken cancellationToken = default)
    {
        var section = _config.GetSection("Smtp");
        var host = section["Host"];
        var user = section["User"];
        var password = section["Password"];
        var to = section["To"];

        if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(to))
        {
            _logger.LogWarning("Smtp settings are not configured; contact message from {Email} was not emailed.", email);
            throw new InvalidOperationException("Smtp is not configured.");
        }

        var port = section.GetValue("Port", 587);
        var enableSsl = section.GetValue("EnableSsl", true);
        var from = section["From"] is { Length: > 0 } configuredFrom ? configuredFrom : user;

        using var client = new SmtpClient(host, port)
        {
            EnableSsl = enableSsl,
            Credentials = new NetworkCredential(user, password),
        };

        using var mail = new MailMessage
        {
            From = new MailAddress(from, "Portfolio Contact Form"),
            Subject = $"Portfolio message from {name}",
            Body = $"From: {name} <{email}>\n\n{message}",
            IsBodyHtml = false,
        };
        mail.To.Add(to);
        mail.ReplyToList.Add(new MailAddress(email, name));

        await client.SendMailAsync(mail, cancellationToken);
    }
}
