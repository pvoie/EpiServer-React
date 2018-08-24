using System.Collections.Generic;
using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Media;

namespace Episerver_React.Business.Rendering.Services
{
    public class SiteImageRenderingService : IContentRenderingService<SiteImage>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>
            {
                new TemplateModel
                {
                    Name = "Site Image",
                    Inherit = true,
                    AvailableWithoutTag = true,
                    Default = true,
                    Tags = new[] { GlobalSettings.RenderingTags.LogoCollectionItem },
                    Path = TemplateCoordinator.BlockPath("LogoCollectionBlock/SiteImage")
                }
            };
        }
    }
}