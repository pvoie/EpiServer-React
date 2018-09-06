using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Rendering.Services
{
    public class FaqsBlockRenderingService : IContentRenderingService<FaqsBlock>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>{
                new TemplateModel
                {
                    Name = "FAQ Tabs Item",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.RenderingTags.FaqTabsItem },
                    Path = TemplateCoordinator.BlockPath("FaqsBlock/FaqTabsItem")
                }
            };
        }
    }
}