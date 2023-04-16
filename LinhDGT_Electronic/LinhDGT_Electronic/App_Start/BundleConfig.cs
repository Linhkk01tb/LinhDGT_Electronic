using System.Web;
using System.Web.Optimization;

namespace LinhDGT_Electronic
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Content/js/show-hide.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/container.css",
                      "~/Content/css/layouts/header.css",
                      "~/Content/css/layouts/menu.css",
                      "~/Content/css/layouts/body.css",
                      "~/Content/css/layouts/footer.css",
                      "~/Content/css/components/button.css",
                      "~/Content/css/components/input.css",
                      "~/Content/css/components/select.css",
                      "~/Content/css/components/table.css",
                      "~/Content/css/components/text-area.css",
                      "~/Content/css/form/pop_up.css",
                      "~/Content/css/form/sign_up.css",
                      "~/Content/assets/font/fontawesome-free-6.3.0-web/css/all.min.css"
                      ));
        }
    }
}
