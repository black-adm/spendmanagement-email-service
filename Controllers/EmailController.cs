using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace spendmanagement_mail_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("adrien.rutherford25@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("adrien.rutherford25@ethereal.email"));
            email.Subject = "Testando ...";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("adrien.rutherford25@ethereal.email", "mQzCd3uKA6tm7xvxDF");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
