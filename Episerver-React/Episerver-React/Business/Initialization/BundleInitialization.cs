using System.Web.Optimization;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace Episerver_React.Business.Initialization
{
    [InitializableModule]
    public class BundleInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                RegisterBundles(BundleTable.Bundles);
            }
        }

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/static/css/default-styles.css")
                .IncludeDirectory("~/Static/css/","*.css", true)
            );

            bundles.Add(new ScriptBundle("~/static/js/default-scripts.js")
               .Include("~/Scripts/jquery-3.3.1.min.js")
           );

            bundles.Add(new ScriptBundle("~/static/js/customscripts.js")
               .IncludeDirectory("~/Static/js/","*.js", true)
           );


        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}