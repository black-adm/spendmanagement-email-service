using SpendManagement.EmailService.Models;

namespace SpendManagement.Services.EmailServices
{
    public interface IEmailService
    {
        void SendEmail(Email request);
    }
}