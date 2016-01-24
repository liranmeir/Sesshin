using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sesshin.DAL;
using Sesshin.Service;
using Sesshin.Website.Models;

namespace Sesshin.Website.Controllers
{
    public class ArticlesController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Index()
        {
            using (var db = new ArticleRepository())
            {
                var articles = db.All.ToList();
                return View(articles);
            }
            
        }

        public ActionResult Details(string englishName)
        {
            if (Utils.IsDispalyActiveTrail(englishName))
            {
                ViewBag.IsDispalyActiveTrail = true;
            }

            using (var db = new ArticleRepository())
            {
                var article = db.Find(englishName);
                if (article != null)
                {

                    var model = new ArticleViewModel
                                    {
                                        Name = article.Name,
                                        BackgroundImages = article.BackgroundImages.Select(img => img.Name).ToList(),
                                        Content = article.Content,
                                        Headline = article.Headline,
                                        PageDescription = article.PageDescription,
                                        PageKeywords = article.PageKeywords,
                                        PageTitle = article.PageTitle,
                                        ID = article.ID
                                    };
                    return View(model);
                }

                throw new HttpException(404, "Not found");
            }
        }
    }
}
