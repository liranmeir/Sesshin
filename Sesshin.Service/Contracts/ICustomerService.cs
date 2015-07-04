using Sesshin.Model;
using Sesshin.Models;

namespace Sesshin.Service.Contracts
{
    public interface ICustomerService
    {
        void AddCustomersToDb(Customer customer);
        void UploadToActiveTrailIfAccepted(Customer customer);
    }
}