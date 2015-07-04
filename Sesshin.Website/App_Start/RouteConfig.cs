using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sesshin.Website
{
    public class RouteConfig
    {
        public static void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
               name: "ProductByName",
               url: "products/{englishName}",
               defaults: new { controller = "Products", action = "Details" }
           );
            routes.MapRoute(
              name: "PricesByProductName",
              url: "products/prices/{englishName}",
              defaults: new { controller = "Products", action = "Prices" }
          );
            routes.MapRoute(
              name: "ArticleByName",
              url: "articles/{englishName}",
              defaults: new { controller = "articles", action = "Details" }
          );

            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
             );
        }
    }
}