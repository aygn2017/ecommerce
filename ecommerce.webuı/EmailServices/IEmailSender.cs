using System.Threading.Tasks;

namespace ecommerce.webui.EmailServices
{
    public interface IEmailSender
    {
         // smtp => gmail, hotmail
         // api  => sendgrid

        Task SendEmailAsync(string email, string subject, string htmlMessage);

    }
}