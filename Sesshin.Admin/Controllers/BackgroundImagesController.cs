using Sesshin.DAL;
using Sesshin.Model;

namespace Sesshin.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;

    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Sesshin.Service;
    using Sesshin.Admin.Models;
    using WebGrease.Css.Extensions;

    public class BackgroundImagesController : Controller
    {
        private SesshinAdminContext db = new SesshinAdminContext();
        private readonly IProductRepository productRepository;
        private readonly IArticleRepository articleRepository;

        public BackgroundImagesController() 
        {
            productRepository = new ProductRepository();
            articleRepository =new ArticleRepository();
        }

        public ViewResult Index()
        {
            return View(db.Images);
        }

       [HttpPost]
       public ActionResult Upload()
       {
           if (Request.Files.Count > 0)
           {
               var file = Request.Files[0];

               if (file != null && file.ContentLength > 0)
               {
                   var fileName = Path.GetFileName(file.FileName);
                   var folderPath = "~" + Utils.GetBackgroundImagesFolder();
                   //var folderPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                   var path = Path.Combine(Server.MapPath(folderPath), fileName);
                   file.SaveAs(path);

                   using (var db = new SesshinAdminContext())
                   {
                       var bg = new BackgroundImage {Name = fileName};
                       db.Images.Add(bg);
                       db.SaveChanges();
                   }
               }
           }

           return RedirectToAction("Index");
       }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                using (var db = new SesshinAdminContext())
                {
                    var image = db.Images.SingleOrDefault(i => i.Id == id);
                    db.Images.Remove(image);
                    db.SaveChanges();

                    DeleteFileFromFlieSys(image);
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new {success = false, message = ex.Message});
            }

        }

        private void DeleteFileFromFlieSys(BackgroundImage image)
        {
            try
            {
                var fileName = image.Name;
                var folderPath = "~" + Utils.GetBackgroundImagesFolder();
                var path = Path.Combine(Server.MapPath(folderPath), fileName);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                //log
                Response.Write(ex.Message);
            }
        }

        public PartialViewResult GetBackgroundImages(int id, string type)
        {
            var selectedImages = new List<BackgroundImage>();
            var unSelectedFiles = new List<BackgroundImage>();

            switch (type)
            {
                case "product":
                    Product product = productRepository.Find(id);
                    if (product != null)
                    {

                        if (product.BackgroundImages.Any())
                        {
                            selectedImages = product.BackgroundImages.ToList();
                        }

                        var allFiles = (from i in db.Images
                                        select i);

                        if (allFiles.Any())
                        {
                            var listAllFiles = allFiles.ToList();
                            unSelectedFiles = (from file in listAllFiles
                                               where !(selectedImages.Any(b => b.Id == file.Id))
                                               select file).ToList();
                        }

                        var model = new BackgroundImageVM()
                                        {
                                            Id = id,
                                            Type = type,
                                            AvailableImages = unSelectedFiles,
                                            SelectedImages = selectedImages
                                        };



                        return PartialView("_BackgroundImages", model);
                    }
                    break;
                case "article":
                    Article article = articleRepository.Find(id);
                    if (article != null)
                    {

                        if (article.BackgroundImages.Any())
                        {
                            selectedImages = article.BackgroundImages.ToList();
                        }

                        var allFiles = (from i in db.Images
                                        select i);

                        if (allFiles.Any())
                        {
                            var listAllFiles = allFiles.ToList();
                            unSelectedFiles = (from file in listAllFiles
                                               where !(selectedImages.Any(b => b.Id == file.Id))
                                               select file).ToList();
                        }

                        var model = new BackgroundImageVM()
                                        {
                                            Id = id,
                                            Type = type,
                                            AvailableImages = unSelectedFiles,
                                            SelectedImages = selectedImages
                                        };



                        return PartialView("_BackgroundImages", model);
                    }
                    break;
            }
        
            return null;
        }
        [HttpPost]
        public JsonResult UpdateImages(int id, int[] arr, string type)
        {
            try
            {
                if (type == "product")
                {
                    var product = db.Products.Find(id);

                    product.BackgroundImages.Clear();

                    if (arr != null)
                    {
                        foreach (var backgroundImageId in arr)
                        {
                            var bgImg = db.Images.Find(backgroundImageId);
                            product.BackgroundImages.Add(bgImg);
                        }
                    }

                    db.SaveChanges();
                }

                else if (type == "article")
                {
                    var article = db.Articles.Find(id);

                    article.BackgroundImages.Clear();
                    if (arr != null)
                    {

                        foreach (var backgroundImageId in arr)
                        {
                            var bgImg = db.Images.Find(backgroundImageId);
                            article.BackgroundImages.Add(bgImg);
                        }
                    }

                    db.SaveChanges();
                }


                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                
                return Json(new { success = false, message = ex.Message });
            }


        }
         
    }
}
