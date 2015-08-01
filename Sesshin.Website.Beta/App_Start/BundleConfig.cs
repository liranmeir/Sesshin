using System.Web;
using System.Web.Optimization;

namespace Sesshin.Website.Beta
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            //new

            bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/fonts/aqua/aqua.css",
                      "~/assets/fonts/nachlieliclm/stylesheet.css",
                      "~/assets/fonts/icon-fonts/styles.css",
                      "~/assets/styles/plugins.css",
                      "~/assets/styles/main.css"));

            bundles.Add(new StyleBundle("~/vendors/css").Include(
                      "~/vendors/flexslider/flexslider.css",
                      "~/vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.css"));


            bundles.Add(new ScriptBundle("~/vendors/script").Include(
                      "~/vendors/jquery/dist/jquery.min.js",
                      "~/vendors/bootstrap/dist/js/bootstrap.min.js",
                      "~/vendors/flexslider/jquery.flexslider-min.js",
                      "~/vendors/jssor-slider/js/jssor.slider.mini.js",
                      "~/vendors/jquery-ui/ui/minified/datepicker.min.js",
                      "~/vendors/countdown/jquery.plugin.min.js",
                      "~/vendors/countdown/jquery.countdown.min.js",
                      "~/vendors/jquery-mousewheel/jquery.mousewheel.min.js",
                      "~/vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.js",
                      "~/vendors/jQuery.dotdotdot/src/js/jquery.dotdotdot.min.js"));


        }
    }
}
