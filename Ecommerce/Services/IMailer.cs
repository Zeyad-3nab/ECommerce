namespace Ecommerce.Services
{
    public interface IMailer
    {
        Task SendEmailAsync(string toEmail, string subject, string htmlMessage);

    }
}
