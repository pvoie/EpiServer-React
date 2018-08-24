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
                .Include("~/static/css/hbh.css")
                .Include("~/static/css/hbh-new.css")
            );

            bundles.Add(new ScriptBundle("~/static/scripts/js-top.js")
                .Include("~/static/js/ektronScripts.js")
                .Include("~/static/js/ccframework/main.js")
            );
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}