using PasswordLess.Infrastructure.Models;

namespace PasswordLess.Infrastructure.Interfaces;

public interface IEmailService
{
    Task SendEmail(EmailModel emailModel);
}