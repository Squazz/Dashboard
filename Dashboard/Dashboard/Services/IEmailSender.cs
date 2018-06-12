using System.Threading.Tasks;

namespace Dashboard.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
