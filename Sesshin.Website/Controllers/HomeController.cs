using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sesshin.DAL;
using Sesshin.Service;
using Sesshin.Service.Contracts;
using Sesshin.Website.Models;
using Sesshin.Models;

namespace Sesshin.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel();

            indexViewModel.LinkBoxes = GetHomeLinkBoxes();

            return View(indexViewModel);
        }

        private List<LinkBoxModel> GetHomeLinkBoxes()
        {
            var list = new List<LinkBoxModel>();

            using (var products = new ProductRepository())
            {
                var selectedProducts = products.All.Where(p => p.Id != 1 && p.Id != 2);

                foreach (var p in selectedProducts.Take(5))
                {
                    list.Add(new LinkBoxModel() { Id = p.Id, Name = p.Name, Link = "/Products/" + p.EnglishName });
                }
            }

            return list;
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.IsRequestMobile = Request.Browser.IsMobileDevice;


                var customerService = IocConfig.IocContiner.Resolve<ICustomerService>();
                var customer = Utils.GetCustomerFromContact(contact);
                customerService.AddCustomersToDb(customer);
                customerService.UploadToActiveTrailIfAccepted(customer);


                var emailService = IocConfig.IocContiner.Resolve<IEmailService>();
                emailService.SendEmail(contact);

                return RedirectToAction("ThankYou", "Home");
            }

            ViewBag.IsError = true;
            return View();
        }

        public ActionResult ThankYou()
        {
            return View("ThankYou");
        }
    }
}
