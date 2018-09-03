using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Episerver_React.Business.Rendering;
using Episerver_React.Business.Rendering.Services;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Media;
using StructureMap;

namespace Episerver_React.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            var container = context.StructureMap();
            container.Configure(ConfigureContainer);

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        { }

        private static void ConfigureContainer(ConfigurationExpression container)
        {
            //Swap out the default ContentRenderer for our custom
            container.For<IContentRenderer>().Use<ErrorHandlingContentRenderer>();

            // rendering services

            container.For<IContentRenderingService<CallToActionCard>>().Use<CallToActionCardRenderingService>();

            container.For<IContentRenderingService<LinkItem>>().Use<LinkItemRenderingService>();

            container.For<IContentRenderingService<SiteImage>>().Use<SiteImageRenderingService>();
            container.For<IContentRenderingService<GroupedTilesBlock>>().Use<GroupedTilesRenderingService>();
        }

    }
}