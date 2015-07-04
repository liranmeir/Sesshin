using System.Configuration;
using Sesshin.DAL;
using Sesshin.Model;
using Sesshin.Models;
using Sesshin.Service.Contracts;

namespace Sesshin.Service
{
    public class CustomerService : ICustomerService
    {
       
        private IActiveTrailProxy _activeTrailProxy;
        public void AddCustomersToDb(Customer customer)
        {
            using (var repo = new CustomerRepository())
            { 
                repo.InsertOrUpdate(customer);
                repo.Save();
            }
        }

        public void UploadToActiveTrailIfAccepted(Customer customer)
        {
            if (customer.IsAcceptEmail)
            {
                _activeTrailProxy = new ActiveTrailProxy();

                _activeTrailProxy.UploadCustomer(customer);
            }
            else
            {
                //todo log user does'nt want to recieve emails
            }
        }
    }
}
