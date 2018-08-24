using System.Collections.Generic;
using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;

namespace Episerver_React.Business.Rendering.Services
{
    public class CallToActionCardRenderingService : IContentRenderingService<CallToActionCard>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>
            {
                new TemplateModel
                {
                    Name = "CallToActionCardBlock",
                    Inherit = true,
                    AvailableWithoutTag = true,
                    Default = true,
                    Tags = new[] { GlobalSettings.ContentAreaTags.HeroCta },
                    Path = TemplateCoordinator.BlockPath("CallToActionCard/CallToActionCard")
                }
            };
        }
    }
}