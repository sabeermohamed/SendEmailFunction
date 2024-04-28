using ShoppingCartEmailService.Model;

namespace ShoppingCartEmailService.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}