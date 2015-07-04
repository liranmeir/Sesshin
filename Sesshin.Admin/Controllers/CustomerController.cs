using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sesshin.Model;
using Sesshin.Admin.Models;
using Sesshin.DAL;

namespace Sesshin.Admin.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
		private readonly ICustomerRepository customerRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CustomerController() : this(new CustomerRepository())
        {
        }

        public CustomerController(ICustomerRepository customerRepository)
        {
			this.customerRepository = customerRepository;
        }

        //
        // GET: /Customer/

        public ViewResult Index()
        {
            return View(customerRepository.All);
        }

        //
        // GET: /Customer/Details/5

        public ViewResult Details(int id)
        {
            return View(customerRepository.Find(id));
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid) {
                customerRepository.InsertOrUpdate(customer);
                customerRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(customerRepository.Find(id));
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid) {
                
                customerRepository.InsertOrUpdate(customer);
                customerRepository.Save();
                return RedirectToAction("Index");
            } 
            else 
            { 
				return View();
			}
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(customerRepository.Find(id));
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            customerRepository.Delete(id);
            customerRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult ExportData()
        {
            GridView gv = new GridView();
            gv.DataSource = customerRepository.All.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Customers_"+DateTime.Now.ToShortDateString()+".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                customerRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

