using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Sesshin.Model;

namespace Sesshin.Service
{
    public class Utils
    {
        public static string GetBackgroundImagesFolder()
        {
           return  ConfigurationManager.AppSettings["BackgroundImagesFolder"];
        }



        public static Model.Customer GetCustomerFromContact(Models.Contact contact)
        {
            var customer = new Customer
            {
                Email = contact.Email,
                FirstName = contact.Name,
                Phone = contact.Phone,
                IsAcceptEmail = contact.IsAcceptMail,
                LeadSource = eLeadSource.ContactForm,
                Address = new Address()

            };
            return customer;
        }

        
    }
}
