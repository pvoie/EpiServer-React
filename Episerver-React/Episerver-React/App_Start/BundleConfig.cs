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

            //js
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                   .Include("~/Static/Scripts/jquery-3.3.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                   .Include("~/Static/Scripts/jquery-3.3.1.slim.min.js")
                   .Include("~/Scripts/umd/popper.min.js")
                   .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/myscripts")
                    .Include("~/Static/Scripts/MyScript.js"));

           

           // BundleTable.EnableOptimizations = true;
        }
    }
}
