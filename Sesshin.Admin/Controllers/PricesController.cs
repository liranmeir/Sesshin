using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sesshin.DAL;
using Sesshin.Model;
using Sesshin.Service;

namespace Sesshin.Admin.Controllers
{
    [Authorize]
    public class PricesController : Controller
    {
        private SesshinAdminContext db = new SesshinAdminContext();

        //
        // GET: /Prices/

        //public ActionResult Index(int productId)
        //{
        //   // ViewBag.Product = db.Products.First(p => p.Id== productId);
        //   // return View(db.PriceModels.ToList());
        //    return View();
        //}

        public ActionResult PricesOfProduct(int ProductId)
        {
            var pricesOfProduct = db.PriceModels.Include("Product").Where(p => p.ProductId == ProductId);
             
            return View(pricesOfProduct.ToList());
        }
         
        //
        // GET: /Prices/Create

        public ActionResult Create(int productId)
        {
            var product = db.Products.Single(p => p.Id == 1);
            ViewBag.Product = product;
            return View();
        }

        
        //
        // POST: /Prices/Create

        [HttpPost]
        public ActionResult Create(PriceModel pricemodel)
        {
            if (ModelState.IsValid)
            {
                db.PriceModels.Add(pricemodel);
                db.SaveChanges();
                return RedirectToAction("PricesOfProduct", new { productId = pricemodel.ProductId });
            }

            return View(pricemodel);
        }

        //
        // GET: /Prices/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PriceModel pricemodel = db.PriceModels.Include("Product").First(p => p.Id == id);
            if (pricemodel == null)
            {
                return HttpNotFound();
            }

           // ViewBag.ProductId = new SelectList(db.Products, "ID", "Name", pricemodel.Product.Id);
            
            return View(pricemodel);
        }

        //
        // POST: /Prices/Edit/5

        [HttpPost]
        public ActionResult Edit(PriceModel pricemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricemodel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PricesOfProduct", new { productId = pricemodel.ProductId });
            }

            return View(pricemodel);
        }

        //
        // GET: /Prices/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PriceModel pricemodel = db.PriceModels.Find(id);
            if (pricemodel == null)
            {
                return HttpNotFound();
            }
            return View(pricemodel);
        }

        //
        // POST: /Prices/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        { 
            PriceModel pricemodel = db.PriceModels.Find(id);
            var productid = pricemodel.ProductId;
            db.PriceModels.Remove(pricemodel);
            db.SaveChanges();
            return RedirectToAction("PricesOfProduct", new { productId = productid });
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}