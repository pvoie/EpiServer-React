using System.Linq;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Episerver_React.Business.Rendering.Services;
using Episerver_React.Controllers;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Media;

namespace Episerver_React.Business.Rendering
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class TemplateCoordinator : IViewTemplateModelRegistrator
    {
        #region Services

        internal static Injected<IContentRenderingService<CallToActionCard>> _ctaRenderingService;
        internal static Injected<IContentRenderingService<LinkItem>> _linkItemRenderingService;
        internal static Injected<IContentRenderingService<SiteImage>> _siteImageRenderingService;
        #endregion Services

        #region Paths

        public const string PagePartialsFolder = "~/Views/PagePartials/";
        public const string BlockFolder = "~/Views/Blocks/";
        public const string SharedFolder = "~/Views/Shared/";
        public const string SharedDisplayTemplatesFolder = "~/Views/Shared/DisplayTemplates/";

        #endregion Paths

        public static void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
            //Disable DefaultPageController for page types that shouldn't have any renderer as pages
            if (args.ItemToRender is IContainerPage && args.SelectedTemplate != null &&
                args.SelectedTemplate.TemplateType == typeof(DefaultPageController))
            {
                args.SelectedTemplate = null;
            }
        }

        /// <summary>
        /// Registers renderers/templates which are not automatically discovered,
        /// i.e. partial views whose names does not match a content type's name.
        /// </summary>
        /// <remarks>
        /// Using only partial views instead of controllers for blocks and page partials
        /// has performance benefits as they will only require calls to RenderPartial instead of
        /// RenderAction for controllers.
        /// Registering partial views as templates this way also enables specifying tags and
        /// that a template supports all types inheriting from the content type/model type.
        /// </remarks>
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            // Add BasePage templates
            viewTemplateModelRegistrator.Add(typeof(CallToActionCard),
               _ctaRenderingService.Service.GetAvailableTemplates().ToArray());

            viewTemplateModelRegistrator.Add(typeof(LinkItem),
               _linkItemRenderingService.Service.GetAvailableTemplates().ToArray());

            viewTemplateModelRegistrator.Add(typeof(SiteImage),
                _siteImageRenderingService.Service.GetAvailableTemplates().ToArray());
        }

        public static string ViewPath(string folder, string fileName)
        {
            return string.Format("{0}{1}.cshtml", folder, fileName);
        }

        public static string BlockPath(string fileName)
        {
            return string.Format("{0}{1}.cshtml", BlockFolder, fileName);
        }

        public static string PagePartialPath(string fileName)
        {
            return string.Format("{0}{1}.cshtml", PagePartialsFolder, fileName);
        }

        public static string SharedPath(string fileName)
        {
            return string.Format("{0}{1}.cshtml", SharedFolder, fileName);
        }
    }
}