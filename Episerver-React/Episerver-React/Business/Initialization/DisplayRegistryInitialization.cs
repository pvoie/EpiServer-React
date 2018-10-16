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

                ////options.Add("Standard", "Standard", GlobalSettings.ContentAreaTags.StandardCard, "Standard Card", "");
                //options.Add("FullWidthCard", "Full Width", GlobalSettings.ContentAreaTags.TierOne, "Full Width Card", "");
                //options.Add("HalfWidthCard", "Half Width", GlobalSettings.ContentAreaTags.TierTwo, "Half Width Card", "");
                //options.Add("ThirdWidthCard", "One Third Width", GlobalSettings.ContentAreaTags.TierThree, "One Third Width Card", "");
                ////options.Add("TwoThirdsWidthCard", "Two Thirds Width", GlobalSettings.ContentAreaTags.TwoThirdsWidthCard, "Two Thirds Width Card", "");
                ////options.Add("SquareCard", "Square", GlobalSettings.ContentAreaTags.SquareCard, "Square Card", "");
                ////options.Add("WideBannerCard", "Wide Banner", GlobalSettings.ContentAreaTags.WideBannerCard, "Wide Banner Card", "");
                //options.Add("BlogImagesTop", "Top Image(s)", GlobalSettings.ContentAreaTags.TopImage, "Blog content with images at the top", "");
                //options.Add("BlogImagesRight", "Right Image(s)", GlobalSettings.ContentAreaTags.RightImage, "Blog content with images to the right", "");
                //options.Add("BlogImagesBottom", "Bottom Image(s)", GlobalSettings.ContentAreaTags.BottomImage, "Blog content with images at the bottom", "");
                ////options.Add("BlogImagesLeft", "Left Image(s)", GlobalSettings.ContentAreaTags.BlogImagesLeft, "Blog content with images to the left", "");

                AreaRegistration.RegisterAllAreas();
            }
        }

        public void Uninitialize(InitializationEngine context) { }
    }
}