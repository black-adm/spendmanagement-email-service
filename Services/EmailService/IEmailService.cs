using spendmanagement_mail_service.Models;

namespace spendmanagement_mail_service.Services.EmailService;

public interface IEmailService
{
    void SendEmail(Email request);
}