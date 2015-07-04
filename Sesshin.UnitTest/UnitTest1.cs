using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sesshin.Models;
using Sesshin.Service;

namespace Sesshin.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmail()
        {
            var contact = new Contact
            {
                Email = "somebody@gmail.com",
                IsAcceptMail = true,
                IsRequestMobile = true,
                Name = "somebody",
                Phone = "021231231",
                Remarks = "someremovardsafdf"
            };

            new EmailService().SendEmail(contact);
        }
    }
}
