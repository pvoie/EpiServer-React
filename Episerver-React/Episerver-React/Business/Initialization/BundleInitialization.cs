﻿using System.Web.Optimization;
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
                .IncludeDirectory("~/Static/css/", "*.css", true)
            );

            bundles.Add(new StyleBundle("~/static/css/menu-styles.css")
               .Include("~/Static/css/menu.css")
            );

            bundles.Add(new StyleBundle("~/static/css/all-recipes.css")
              .Include("~/Static/css/recipeAll.css")
           );

            bundles.Add(new ScriptBundle("~/static/js/default-scripts.js")
               .Include("~/Scripts/jquery-3.3.1.min.js")
               .Include("~/Static/js/MyScript.js")
           );

            bundles.Add(new ScriptBundle("~/static/js/homescripts.js")
               .Include("~/Static/js/home.js")
               
           );

            bundles.Add(new ScriptBundle("~/static/js/menu-scripts.js")
             .Include("~/Static/js/menu.js")
             .Include("~/Static/js/TweenMax.min.js")
           );

            bundles.Add(new ScriptBundle("~/static/js/all-recipes.js")
                .Include("~/Static/js/recipeAll.js"));


            bundles.Add(new ScriptBundle("~/static/js/common.js")
                .Include("~/Static/js/common.js"));

            bundles.Add(new ScriptBundle("~/static/js/site-map.js")
                .Include("~/Static/js/siteMap.js"));

        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}