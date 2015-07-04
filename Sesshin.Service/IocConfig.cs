using Microsoft.Practices.Unity;
using Sesshin.Service.Contracts;

namespace Sesshin.Service
{
    public class IocConfig
    {
        public static UnityContainer IocContiner;

        public static void Register()
        {
            IocContiner = new UnityContainer();

            IocContiner.RegisterType<ICustomerService, CustomerService>()
                     .RegisterType<IEmailService, EmailService>();
        }
    }
}