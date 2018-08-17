using System.Web.Optimization;

namespace Episerver_React
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {            
            //css
            bundles.Add(new StyleBundle("~/Content/css")
                    .IncludeDirectory("~/Static/Styles", "*.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapCss")
                    .Include("~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/MenuV2css")
                    .Include("~/Static/Styles/MenuV2Style.css"));

            //js
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                   .Include("~/Static/Scripts/jquery-3.3.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUI")
               .Include("~/Static/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                   .Include("~/Static/Scripts/jquery-3.3.1.slim.min.js")
                   .Include("~/Scripts/umd/popper.min.js")
                   .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/myscripts")
                    .Include("~/Static/Scripts/MyScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/menuV2scripts")
                .Include("~/Static/Scripts/MenuV2Script.js"));



           // BundleTable.EnableOptimizations = true;
        }
    }
}
