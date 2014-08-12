using System.Web;
using System.Web.Optimization;

namespace Dashboard
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery")
            //    .Include("~/Scripts/jquery-{version}.js")
            //    .Include("~/Scripts/kendo/2014.1.318/kendo.web.min.js")
            //    .Include("~/Scripts/globalScripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/require")
                .Include("~/Scripts/require.js")
                .Include("~/Scripts/require.config.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css", "~/Content/site.css")
                .Include("~/Content/kendo/2014.1.318/kendo.common.min.css")
                .Include("~/Content/kendo/2014.1.318/kendo.default.min.css"));

            #if RELEASE 
            BundleTable.EnableOptimizations = true;
            #endif
        }
    }
}
