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


        public static bool IsMobileDevice(string userAgent)
        {
            return(userAgent.Contains("iPhone") || userAgent.Contains("Windows Phone") || userAgent.Contains("Android"));
        }

        public static bool IsDispalyActiveTrail(string englishName)
        {
            return englishName == "shiatsu-at-home-for pregnant-woman" ||
                   englishName == "medical-massage"||
                   englishName == "couple-massage"||
                   englishName == "single-massage";
        }
    }
}
