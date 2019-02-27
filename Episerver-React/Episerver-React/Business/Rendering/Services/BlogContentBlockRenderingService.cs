using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Rendering.Services
{
    public class BlogContentBlockRenderingService : IContentRenderingService<BlogContentBlock>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>
            {
                new TemplateModel
                {
                    Name = "Top Image",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = true,
                    Tags = new[] { GlobalSettings.ContentAreaTags.TopImage },
                    Path = TemplateCoordinator.BlockPath("BlogContentBlock/TopImage")
                },
                new TemplateModel
                {
                    Name = "Bottom Image",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.BottomImage },
                    Path = TemplateCoordinator.BlockPath("BlogContentBlock/BottomImage")
                },
                new TemplateModel
                {
                    Name = "Right Image",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.RightImage },
                    Path = TemplateCoordinator.BlockPath("BlogContentBlock/RightImage")
                }
            };
        }
    }
}