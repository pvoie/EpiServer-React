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
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.HeroCta },
                    Path = TemplateCoordinator.BlockPath("CallToActionCard/CallToActionCard")
                },
                 new TemplateModel
                {
                    Name = "GroupedTilesItem",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.RenderingTags.GroupedTilesItem },
                    Path = TemplateCoordinator.BlockPath("CallToActionCard/GroupedTilesItem")
                },
                 new TemplateModel
                {
                    Name = "CenteredTextBannerItem",
                    Inherit = false,
                    AvailableWithoutTag = true,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.CenteredTextBannerItem },
                    Path = TemplateCoordinator.BlockPath("CallToActionCard/CenteredTextBannerItem")
                },
                 new TemplateModel
                {
                    Name = "CenteredTextImageBannerItem",
                    Inherit = true,
                    AvailableWithoutTag = true,
                    Default = true,
                    Tags = new[] { GlobalSettings.ContentAreaTags.CenteredTextImageBannerItem },
                    Path = TemplateCoordinator.BlockPath("CallToActionCard/CenteredTextImageBannerItem")
                },
                 new TemplateModel
                {
                    Name = "SimpleCenteredText",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.SimpleCenteredText },
                    Path = TemplateCoordinator.BlockPath("CallToActionCard/SimpleCenteredText")
                },
                 new TemplateModel
                {
                    Name = "FooterCenteredText",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.FooterCenteredText },
                    Path = TemplateCoordinator.BlockPath("CallToActionCard/FooterCenteredText")
                },
                 new TemplateModel
                {
                    Name = "Question",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.RenderingTags.RegularCta },
                    Path = TemplateCoordinator.BlockPath("CallToActionCard/QuestionCta")
                }
            };
        }
    }
}