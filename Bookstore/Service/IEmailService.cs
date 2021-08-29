using Bookstore.Models;
using System.Threading.Tasks;

namespace Bookstore.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEmailConfirmation(UserEmailOptions userEmailOptions);
    }
}