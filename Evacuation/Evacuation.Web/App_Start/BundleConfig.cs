using System.Web;
using System.Web.Optimization;

namespace Evacuation.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           // bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
           //             "~/Scripts/neon/jquery-{version}.js"));

           // bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
           //             "~/Scripts/jquery.validate*"));

           // // Use the development version of Modernizr to develop with and learn from. Then, when you're
           // // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
           // bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
           //             "~/Scripts/modernizr-*"));

           // bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
           //           "~/Scripts/neon/bootstrap.js",
           //           "~/Scripts/respond.js"));          


            var bundle = new StyleBundle("~/assets/js/jquery-ui/css/no-theme/virtual.css");
            bundle.Include("~/assets/js/jquery-ui/css/no-theme/jquery-ui-1.10.3.custom.css",
                 "~/assets/js/jquery-ui/css/no-theme/jquery.ui.theme.css");
            bundles.Add(bundle);

            bundle = new StyleBundle("~/assets/css/font-icons/entypo/css/virtual.css");
            bundle.Include("~/assets/css/font-icons/entypo/css/entypo.css");
            bundles.Add(bundle);

            bundle = new StyleBundle("~/assets/css/font-icons/font-awesome/css/virtual.css");
            bundle.Include("~/assets/css/font-icons/font-awesome/css/font-awesome.css");
            bundles.Add(bundle);

            bundle = new StyleBundle("~/assets/css/virtual.css");
            bundle.Include(
                "~/assets/css/bootstrap.css",
                "~/assets/css/neon-core.css",
                "~/assets/css/neon-theme.css",
                "~/assets/css/neon-forms.css",
                "~/assets/css/custom.css",
                "~/assets/js/select2/select2.css"
            );
            bundles.Add(bundle);                
                 
                
            var bundle1 = new ScriptBundle("~/assests/js/virtual.js");
            bundle1.Include(
                "~/assets/js/jquery-1.11.0.min.js",
                "~/assets/js/bootstrap.js",
                "~/assets/js/neon-custom.js",
                "~/assets/js/gsap/main-gsap.js",
                "~/assets/js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js",
                "~/assets/js/joinable.js",
                "~/assets/js/resizeable.js",
                "~/assets/js/neon-api.js",
                "~/assets/js/jquery.validate.min.js",
                "~/assets/js/neon-login.js",
                "~/assets/js/neon-demo.js"
                );
            bundles.Add(bundle1);
        }
    }
}
