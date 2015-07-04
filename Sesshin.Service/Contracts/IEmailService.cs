using Sesshin.Models;

namespace Sesshin.Service.Contracts
{
    public interface IEmailService
    {
        void SendEmail(Contact contact);
    }
}