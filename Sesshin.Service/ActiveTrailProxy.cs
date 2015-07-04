using System.Configuration;
using Sesshin.Model;
using Sesshin.Service.ActiveTrailApi.CustomersServiceProxy;
using Sesshin.Service.Contracts;

namespace Sesshin.Service
{
    public class ActiveTrailProxy : IActiveTrailProxy
    {
        private readonly AuthHeader _authHeader;
        private readonly CustomerServiceSoapClient _client;
        private readonly string _user = ConfigurationManager.AppSettings["ActiveTrail.User"];
        private readonly string _pass = ConfigurationManager.AppSettings["ActiveTrail.Pass"];
        public ActiveTrailProxy()
        {
            _authHeader = new AuthHeader { Username = _user, Password = _pass };
            _client = new CustomerServiceSoapClient();
            _authHeader.Token = _client.Login(_authHeader);
        }

        public void UploadCustomer(Customer customer)
        {
            const int groupid = 164713;//לקוחות עיסוי עד הבית

            // Create a new instance of WebCustomer and set some values in
            var webCustomer = new WebCustomer
            {
                Email = customer.Email ?? string.Empty,
                FirstName = customer.FirstName ?? string.Empty,
                LastName = customer.LastName ?? string.Empty,
                Anniversary = customer.Aniversery.HasValue ? customer.Aniversery.Value.ToString("MM/dd/yyyy") : string.Empty,
                Birthday = customer.Birthday.HasValue ? customer.Birthday.ToString("MM/dd/yyyy") : string.Empty,
                Phone2 = customer.Phone ?? string.Empty,
            };
            
            if (customer.Address != null && customer.Address.City != null)
            {
                webCustomer.City = customer.Address.City;
            }

            // Call the import customer method
            var response = _client.ImportCustomer(_authHeader, webCustomer, new [] { groupid }, new int[0]);

            if (response.Result != "success")
            {
                //todo : write to log
            }
        }
    }
}