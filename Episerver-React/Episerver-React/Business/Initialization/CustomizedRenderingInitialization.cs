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
                ctx.DisableBuiltinDisplayOptions = true;
                ctx.CustomDisplayOptions.Add<TierOneDisplayOption>();
                ctx.CustomDisplayOptions.Add<TierTwoDisplayOption>();
                ctx.CustomDisplayOptions.Add<TierThreeDisplayOption>();
                ctx.CustomDisplayOptions.Add<TopImageDisplayOption>();
                ctx.CustomDisplayOptions.Add<BottomImageDisplayOption>();
                ctx.CustomDisplayOptions.Add<RightImageDisplayOption>();
            });
        }

        public void Uninitialize(InitializationEngine context)
        {
            _templateResolver.Service
                .TemplateResolved -= TemplateCoordinator.OnTemplateResolved;
        }
    }

    public class TierOneDisplayOption : DisplayModeFallback
    {
        public TierOneDisplayOption()
        {
            Name = "Full Width";
            Tag = GlobalSettings.ContentAreaTags.TierOne;
            LargeScreenWidth = 12;
            MediumScreenWidth = 11;
            SmallScreenWidth = 8;
            ExtraSmallScreenWidth = 4;
        }
    }

    public class TierTwoDisplayOption : DisplayModeFallback
    {
        public TierTwoDisplayOption()
        {
            Name = "Half Width";
            Tag = GlobalSettings.ContentAreaTags.TierTwo;
            LargeScreenWidth = 12;
            MediumScreenWidth = 11;
            SmallScreenWidth = 8;
            ExtraSmallScreenWidth = 4;
        }
    }

    public class TierThreeDisplayOption : DisplayModeFallback
    {
        public TierThreeDisplayOption()
        {
            Name = "One Third Width";
            Tag = GlobalSettings.ContentAreaTags.TierThree;
            LargeScreenWidth = 12;
            MediumScreenWidth = 11;
            SmallScreenWidth = 8;
            ExtraSmallScreenWidth = 4;
        }
    }

    public class TopImageDisplayOption : DisplayModeFallback
    {
        public TopImageDisplayOption()
        {
            Name = "Top Image";
            Tag = GlobalSettings.ContentAreaTags.TopImage;
            LargeScreenWidth = 12;
            MediumScreenWidth = 11;
            SmallScreenWidth = 8;
            ExtraSmallScreenWidth = 4;
        }
    }

    public class BottomImageDisplayOption : DisplayModeFallback
    {
        public BottomImageDisplayOption()
        {
            Name = "Bottom Image";
            Tag = GlobalSettings.ContentAreaTags.BottomImage;
            LargeScreenWidth = 12;
            MediumScreenWidth = 11;
            SmallScreenWidth = 8;
            ExtraSmallScreenWidth = 4;
        }
    }

    public class RightImageDisplayOption : DisplayModeFallback
    {
        public RightImageDisplayOption()
        {
            Name = "Right Image";
            Tag = GlobalSettings.ContentAreaTags.RightImage;
            LargeScreenWidth = 12;
            MediumScreenWidth = 11;
            SmallScreenWidth = 8;
            ExtraSmallScreenWidth = 4;
        }
    }








}