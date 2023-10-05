using Microsoft.AspNetCore.Mvc;
using spendmanagement_mail_service.Models;
using spendmanagement_mail_service.Services.EmailService;

namespace spendmanagement_mail_service.Controllers
{
    [Route("api/[controller]")]
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
    }
}
