using Microsoft.AspNetCore.Mvc;
using SpendManagement.Services.EmailServices;
using SpendManagement.EmailService.Models;

namespace SpendManagement.EmailService.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(Email request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }

        [HttpPost("subscribe")]
        public IActionResult SendSubscribeEmail([FromBody] Email subscribe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = new Email
            {
                To = subscribe.To
            };

            _emailService.SendEmail(email);
            return Ok("Email enviado com sucesso");
        }
    }
}