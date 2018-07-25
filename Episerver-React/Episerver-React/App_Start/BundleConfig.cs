using System.Web.Optimization;

namespace Episerver_React
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //var path= "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js";

           // var jBundle = new ScriptBundle("~/bundles/jquery1", path);

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                   .Include("~/Static/Scripts/jquery-3.3.1.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                   .IncludeDirectory("~/Static/Styles","*.css"));

            bundles.Add(new ScriptBundle("~/bundles/myscripts")
                    .Include("~/Static/Scripts/MyScript.js"));

           // bundles.Add(jBundle);

           // BundleTable.EnableOptimizations = true;
        }
    }
}
