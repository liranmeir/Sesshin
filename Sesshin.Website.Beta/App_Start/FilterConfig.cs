using System.Web;
using System.Web.Mvc;

namespace Sesshin.Website.Beta
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
