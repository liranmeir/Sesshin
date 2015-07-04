using Sesshin.Admin.Models;
using Sesshin.DAL;
using Sesshin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sesshin.Admin.Controllers
{
    public class TestSPController : Controller
    {
        //
        // GET: /TestSP/

        public ActionResult Index()
        {
            using (var db = new SesshinAdminContext()) 
            {
               var query = db.Database.SqlQuery<TestSP>("LookupArticles");
               var result = query.ToList();
               var first = result.FirstOrDefault().NameTEST;
            }

            return null;
        }
         
    }
}
