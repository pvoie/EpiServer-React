using System.Collections.Generic;
using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;

namespace Episerver_React.Business.Rendering.Services
{
    public class LinkItemRenderingService : IContentRenderingService<LinkItem>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>
            {
                new TemplateModel
                {
                    Name = "Item Link",
                    Inherit = true,
                    AvailableWithoutTag = true,
                    Default = true,
                    Tags = new[] { GlobalSettings.RenderingTags.LogoCollectionItem },
                    Path = TemplateCoordinator.BlockPath("LogoCollectionBlock/LinkItem")
                }
            };
        }
    }
}