using System.Web;
using System.Web.Optimization;

namespace TheAmazingRace
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/main-js").Include(
                        "~/Scripts/owl.carousel.min.js", 
                        "~/Scripts/jquery.magnific-popup.js",
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin-js").Include(
                        "~/Scripts/admin/adminlte.js",
                        "~/Scripts/jquery-ui-1.12.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable-js").Include(
                        "~/Scripts/admin/jquery.dataTables.min.js",
                        "~/Scripts/admin/dataTables.bootstrap.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/main-css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/text-align-bs.css",
                      "~/Content/font-awesome/font-awesome.min.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/owl.theme.default.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/admin-css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/text-align-bs.css",
                      "~/Content/font-awesome/font-awesome.min.css",
                      "~/Content/admin/AdminLTE.css",
                      "~/Content/admin/skins/skin-blue.css",
                      "~/Content/admin/dataTables.bootstrap.min.css",
                      "~/Content/admin/jquery-sortable.css"));
        }
    }
}
