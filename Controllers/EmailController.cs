using Microsoft.AspNetCore.Mvc;
using spendmanagement_mail_service.Models;
using spendmanagement_mail_service.Services.EmailService;

namespace spendmanagement_mail_service.Controllers
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
            try
            {
                _emailService.SendEmail(request);
                return Ok();
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao enviar seu e-mail!.");    
            }
        }
    }
}