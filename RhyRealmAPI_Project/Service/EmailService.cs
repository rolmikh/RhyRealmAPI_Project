using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using RhyRealmAPI_Project.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace RhyRealmAPI_Project.Service
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpOptions)
        {
            _smtpSettings = smtpOptions.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("RhyRealm", _smtpSettings.Login));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();

            string login = Environment.GetEnvironmentVariable("Login");
            string password = Environment.GetEnvironmentVariable("Password");
            await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.UseSsl);
            await client.AuthenticateAsync(login, password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

        }
        
    }
}
