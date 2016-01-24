using System.Linq;
using System.Web.Mvc;
using Sesshin.DAL;
using Sesshin.Model;
using Sesshin.Service;
using Sesshin.Website.Models;

namespace Sesshin.Website.Controllers
{
    public class ProductsController : Controller
    { 
        //
        // GET: /Products/

        //public ActionResult Details(int id)
        public ActionResult Details(string englishName)
        {
            if (Utils.IsDispalyActiveTrail(englishName))
            {
                ViewBag.IsDispalyActiveTrail = true;
            }

            using (var db = new   ProductRepository())
            {
                //var product = db.Find(id);
                var product = db.Find(englishName);
                if (product != null)
                {

                    var detailsViewModel = new ProductsDetailsViewModel
                                               {
                                                   ProductId = product.Id,
                                                   EnglishName = product.EnglishName,
                                                   ProductName = product.Name,
                                                   Text = product.Description,
                                                   BackgroundImages = product.BackgroundImages.Select(i=>i.Name).ToList(),

                                                   PageDescription = product.PageDescription,
                                                   PageKeywords = product.PageKeywords,
                                                   PageTitle = product.PageTitle
                                               };
                    //"double-massage_bg.png;main-massage_bg1.png"
                    detailsViewModel.IsDisplayPriceLink = product.PriceModels.Count > 0;
                    return View(detailsViewModel);
                }
                return HttpNotFound(); 
            }

       
            
        }

        public ActionResult Prices(string englishName)
        {
            using (var db = new ProductRepository())
            { 
                
                var product = db.Find(englishName);
                var prices = product.PriceModels;


                var pricesVm = new PricesViewModel
                                   {
                                       PageTitle = product.PageTitle,
                                       PageDescription = product.PageDescription,
                                       PageKeywords = product.PageKeywords,
                                       BackgroundImages = product.BackgroundImages.Select(i => i.Name).ToList()
                                       
                                   };
                foreach (var priceModel in prices)
                {
                    pricesVm.LinkBoxes.Add(GetLinkBoxFromPriceModel(priceModel));
                }
                 
                return View(pricesVm);
            }
        }

        private PriceLinkBox GetLinkBoxFromPriceModel(PriceModel priceModel)
        {
            return new PriceLinkBox
                       {
                           Id = priceModel.Id,
                           Name = priceModel.Title,
                           Minutes = priceModel.Duration,
                           Price = priceModel.Price.ToString(),
                           SubText = priceModel.SubTitle,
                           Description = priceModel.Description
                       };
        } 
    }
}
