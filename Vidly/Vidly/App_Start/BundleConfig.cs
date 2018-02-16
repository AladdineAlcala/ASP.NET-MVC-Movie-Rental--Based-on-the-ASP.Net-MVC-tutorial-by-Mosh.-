using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                                         "~/Scripts/jquery-{version}.js",
                                        "~/Scripts/bootstrap.js",
                                        "~/Scripts/bootbox.js",
                                        "~/Scripts/typeahead.bundle.js",
                                         "~/Scripts/respond.js",
                                         "~/Scripts/toastr.js",
                                         "~/Scripts/DataTables/jquery.dataTables.js",
                                         "~/Scripts/DataTables/dataTables.bootstrap.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/My_StyleSheet.css",
                      "~/Content/bootstrap.css",
                      "~/Content/toastr.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/site.css"));

            //Create bundel for jQueryUI  
            //js  
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui-{version}.js"));
            //css  
            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(
                   "~/Content/jquery-ui.css"));
        }
    }
}
