using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace Ecommerce.Services
{
    public class EmailSender : IMailer 
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromMail ="zeyadenab220@gmail.com";
            var fromPassword = "zeyadenab2582003";
            var message=new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(email);
            message.Body= $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);
        }
    }
}
