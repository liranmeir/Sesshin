
using System.Web.Optimization;
namespace Sesshin.Website 
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/MobileJS").Include(
        "~/Scripts/jquery.mobile-{version}.js",
        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/MobileCSS").Include(
              "~/Content/jquery.mobile.structure-{version}.min.css",
              "~/Content/jquery.mobile-{version}.css"));
        }
    }
}