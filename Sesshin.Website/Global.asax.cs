using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Sesshin.DAL;
using Sesshin.Service;
using System.Data.Entity;
using Sesshin.DAL.Migrations;

namespace Sesshin.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly IDictionary<string, string> FileToUrls = InitRoutingDictionary();

        private static IDictionary<string,string> InitRoutingDictionary()
        { 
            var dic = new Dictionary<string, string>();

            foreach (var redirect in new RedirectRepository().All)
            {
                if (!dic.ContainsKey(redirect.OldFile))
                 dic.Add( redirect.OldFile,redirect.NewPath );
            }

            return dic;
        }
 
         
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.Register(RouteTable.Routes);
            IocConfig.Register();
            // Database.SetInitializer<SesshinAdminContext>(new MigrateDatabaseToLatestVersion<SesshinAdminContext, Configuration>());
        }

        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            var file = Path.GetFileName(Request.Path);

            if (!(file == null || (!file.Contains(".html") && !file.Contains(".htm"))))
            {
                string url;
                if (FileToUrls.TryGetValue(file, out url))
                {
                    this.Response.Status = "301 Moved Permanently";
                    this.Response.AddHeader("Location", url);
                    this.Response.End();
                }
            }
        }
    }
}