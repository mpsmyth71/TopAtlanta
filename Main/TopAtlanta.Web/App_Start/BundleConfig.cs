using System.Web;
using System.Web.Optimization;

namespace TopAtlanta.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/libs_js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Scripts/jquery.dropdown.js")
                .Include("~/Scripts/jquery.html5-placeholder-shim.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/jquery.automod.js")
                .Include("~/Scripts/chosen.jquery.js")
                .Include("~/Scripts/respond.js")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/underscore.js")
                .Include("~/Scripts/snap.svg.js"));

            // organize all app styles in the /Content/App folder
            bundles.Add(new StyleBundle("~/Content/app_css")
                .IncludeDirectory("~/Content/App", "*.css"));

            // organize all app javascript in the /Scripts/App folder
            bundles.Add(new ScriptBundle("~/Scripts/app_js")
                .IncludeDirectory("~/Scripts/App", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/libs_css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-theme.css")
                .Include("~/Content/font-awesome.css")
                .Include("~/Content/jquery.dropdown.css")
                .Include("~/Content/site.css")
                .Include("~/Content/chosen.css"));
        }
    }
}
