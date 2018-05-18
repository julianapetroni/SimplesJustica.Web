using System.Web.Optimization;

namespace SimplesJustica.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Public/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Public/js/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Public/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Public/js/bootstrap.js",
                      "~/Public/js/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Public/css/bootstrap.css",
                      "~/Public/css/site.css"));
        }
    }
}
