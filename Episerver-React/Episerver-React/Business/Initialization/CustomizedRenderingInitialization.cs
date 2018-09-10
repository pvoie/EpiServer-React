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
                ctx.CustomDisplayOptions.Add<SimpleCenteredTextDisplayOption>();
                ctx.CustomDisplayOptions.Add<FooterCenteredTextDisplayOption>();                
                ctx.CustomDisplayOptions.Add<TwoTiles>();                
                ctx.CustomDisplayOptions.Add<ThreeTiles>();
                ctx.CustomDisplayOptions.Add<FourTiles>();
                ctx.CustomDisplayOptions.Add<FiveTiles>();
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
            Name = "Banner - Centered Text";
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
            Name = "Banner - Text with image";
            Tag = GlobalSettings.ContentAreaTags.CenteredTextImageBannerItem;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }


    public class SimpleCenteredTextDisplayOption : DisplayModeFallback
    {
        public SimpleCenteredTextDisplayOption()
        {
            Name = "Centered simple text";
            Tag = GlobalSettings.ContentAreaTags.SimpleCenteredText;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }

    public class FooterCenteredTextDisplayOption : DisplayModeFallback
    {
        public FooterCenteredTextDisplayOption()
        {
            Name = "Footer simple text";
            Tag = GlobalSettings.ContentAreaTags.FooterCenteredText;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }

    public class FiveTiles : DisplayModeFallback
    {
        public FiveTiles()
        {
            Name = "Five Tiles";
            Tag = GlobalSettings.ContentAreaTags.FiveTiles;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }

    public class TwoTiles : DisplayModeFallback
    {
        public TwoTiles()
        {
            Name = "Two Tiles";
            Tag = GlobalSettings.ContentAreaTags.TwoTiles;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }

    public class FourTiles : DisplayModeFallback
    {
        public FourTiles()
        {
            Name = "Four Tiles";
            Tag = GlobalSettings.ContentAreaTags.FourTiles;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }

    public class ThreeTiles : DisplayModeFallback
    {
        public ThreeTiles()
        {
            Name = "Three Tiles";
            Tag = GlobalSettings.ContentAreaTags.ThreeTiles;
            LargeScreenWidth = 12;
            MediumScreenWidth = 8;
            SmallScreenWidth = 3;
            ExtraSmallScreenWidth = 1;
        }
    }
}