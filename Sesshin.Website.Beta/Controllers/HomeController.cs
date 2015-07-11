using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sesshin.Models;
using Sesshin.Service;
using Sesshin.Service.Contracts;
using Sesshin.Website.Beta.Models;

namespace Sesshin.Website.Beta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeVM()
            {
                ContactUsVm =
                    new ContactUsVm()
                    {
                        FormName = "הזמנות",
                        Text = "ככל שתמהרו להזמין כך נוכל לשבץ לכם את המטפלים הטובים ביותר "
                    }
            };
            return View(model);
        }public ActionResult Careers()
        {
            var model = new CareersVM()
            {
                ContactUsVm =
                    new ContactUsVm()
                    {
                        FormName = "השאר פרטים",
                        Text = "מעוניין לפרסם אצלנו השאר פרטים"
                    }
            };


            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}