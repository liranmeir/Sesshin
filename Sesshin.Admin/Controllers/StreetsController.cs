using Sesshin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sesshin.Admin.Controllers
{
    public class StreetsController : Controller
    {
        //
        // GET: /Streets/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStreetsByCityIdAndStreetName(int cityId, string streetName) 
        {
            using (var db = new SesshinAdminContext())
            {
                var streets = db.Streets
                    .Where(c => c.ParentCityId == cityId)
                    .Where(c => c.Name.StartsWith( streetName )).Take(5).ToList();

                return Json(streets, JsonRequestBehavior.AllowGet);
            }  
        }
    }
}
