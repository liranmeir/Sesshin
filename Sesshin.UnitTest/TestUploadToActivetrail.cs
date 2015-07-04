using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sesshin.Model;
using Sesshin.Models;
using Sesshin.Service;
using Sesshin.Service.Contracts;

namespace Sesshin.UnitTest
{
    [TestClass]
    public class TestUploadToActivetrail
    {
        [TestMethod]
        public void TestMethod1()
        {
           // IocConfig.Register();

            var customerService = new CustomerService();//IocConfig.IocContiner.Resolve<ICustomerService>();
            
            var customer = new Customer
            {
                FirstName = "Liran",
                LastName = "Meir",
                Email = "liranmeir@gmail.com"
            };

            customerService.UploadToActiveTrailIfAccepted(customer);
        }
    }
}
