using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.ViewModels.Common;

namespace TodoList.WebApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfigurationSection _config;
        public EmailService(IConfiguration configuration)
        {
            this._config = configuration.GetSection("Email");
        }
        public async Task SendAsync(EmailMessage emailMessage)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailName"]));
            email.To.Add(MailboxAddress.Parse(emailMessage.To));
            email.Subject = emailMessage.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["Host"], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config["EmailName"], _config["Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
