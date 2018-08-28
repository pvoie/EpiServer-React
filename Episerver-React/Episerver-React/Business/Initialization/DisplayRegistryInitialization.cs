using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using Episerver_React.Business.Settings;

namespace Episerver_React.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DisplayRegistryInitialization : IInitializableModule
    {
        internal static Injected<DisplayOptions> _optionsRepo;

        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                // Register Display Options
                var options = _optionsRepo.Service;

                options.Add("Standard", "Standard", GlobalSettings.ContentAreaTags.StandardCard, "Hero CTA", "");
                options.Add("CenteredCTA", "Centered CTA", GlobalSettings.ContentAreaTags.CenteredTextBannerIte, "Centered CTA", "");

                AreaRegistration.RegisterAllAreas();
            }
        }

        public void Uninitialize(InitializationEngine context) { }
    }
}