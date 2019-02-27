using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Rendering.Services
{
    public class CallToActionCardARenderingService : IContentRenderingService<CallToActionCardA>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>
            {
                new TemplateModel
                {
                    Name = "Tier One",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.TierOne },
                    Path = TemplateCoordinator.BlockPath("CallToActionCardA/FullWidth")
                },
                new TemplateModel
                {
                    Name = "Tier Two",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.TierTwo },
                    Path = TemplateCoordinator.BlockPath("CallToActionCardA/HalfWidth")
                },
                new TemplateModel
                {
                    Name = "Tier Three",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.TierThree },
                    Path = TemplateCoordinator.BlockPath("CallToActionCardA/OneThird")
                }
            };
        }
    }
}