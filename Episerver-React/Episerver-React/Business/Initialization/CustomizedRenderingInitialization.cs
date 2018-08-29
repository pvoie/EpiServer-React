using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiBootstrapArea;
using Episerver_React.Business.Rendering;
using Episerver_React.Business.Settings;

namespace Episerver_React.Business.Initialization
{
    /// <summary>
    /// Module for customizing templates and rendering.
    /// </summary>
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CustomizedRenderingInitialization : IInitializableModule
    {
        internal static Injected<TemplateResolver> _templateResolver;

        public void Initialize(InitializationEngine context)
        {
            //Add custom view engine allowing partials to be placed in additional locations
            //Note that we add it first in the list to optimize view resolving when using DisplayFor/PropertyFor
            ViewEngines.Engines.Insert(0, new SiteViewEngine());

            context.Locate.TemplateResolver()
                .TemplateResolved += TemplateCoordinator.OnTemplateResolved;

            ConfigurationContext.Setup(ctx =>
            {
                ctx.RowSupportEnabled = false;
                ctx.AutoAddRow = false;
                ctx.DisableBuiltinDisplayOptions = false;
                ctx.CustomDisplayOptions.Add<CenteredTextDisplayOption>();
                ctx.CustomDisplayOptions.Add<HeroCTAOption>(); 
                 ctx.CustomDisplayOptions.Add<CenteredTextImageDisplayOption>();
            });
        }

        public void Uninitialize(InitializationEngine context)
        {
            _templateResolver.Service
                .TemplateResolved -= TemplateCoordinator.OnTemplateResolved;
        }
    }

    public class CenteredTextDisplayOption : DisplayModeFallback
    {
        public CenteredTextDisplayOption()
        {
            Name = "Centered Text";
            Tag = GlobalSettings.ContentAreaTags.CenteredTextBannerItem;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }
    

    public class HeroCTAOption : DisplayModeFallback
    {
        public HeroCTAOption()
        {
            Name = "Hero CTA";
            Tag = GlobalSettings.ContentAreaTags.HeroCta;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }


    public class CenteredTextImageDisplayOption : DisplayModeFallback
    {
        public CenteredTextImageDisplayOption()
        {
            Name = "Centered Text with image";
            Tag = GlobalSettings.ContentAreaTags.CenteredTextImageBannerItem;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }
}