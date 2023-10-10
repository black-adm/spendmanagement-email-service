using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using SpendManagement.EmailService.Model;

namespace SpendManagement.EmailService.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(Email request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailSettings:From"]));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config["Mailtrap:SmtpHost"], int.Parse(_config["Mailtrap:SmtpPort"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["Mailtrap:SmtpUsername"], _config["Mailtrap:SmtpPassword"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}