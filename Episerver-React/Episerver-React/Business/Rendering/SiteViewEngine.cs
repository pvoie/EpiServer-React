using System.Linq;
using System.Web.Mvc;

namespace Episerver_React.Business.Rendering
{
    public class SiteViewEngine : RazorViewEngine
    {
        private static readonly string[] AdditionalPartialViewFormats = new[]
        {
            TemplateCoordinator.BlockFolder + "{0}.cshtml",
            TemplateCoordinator.PagePartialsFolder + "{0}.cshtml",
            TemplateCoordinator.SharedFolder + "{0}.cshtml",
            TemplateCoordinator.SharedDisplayTemplatesFolder + "{0}.cshtml"
        };

        public SiteViewEngine()
        {
            PartialViewLocationFormats = PartialViewLocationFormats.Union(AdditionalPartialViewFormats).ToArray();
        }
    }
}