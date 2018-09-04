using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Rendering.Services
{
    public class GroupedTilesRenderingService : IContentRenderingService<GroupedTilesBlock>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>{
                new TemplateModel
                {
                    Name = "Two Tiles",
                    Inherit = true,
                    AvailableWithoutTag = true,
                    Default = true,
                    Tags = new[] { GlobalSettings.ContentAreaTags.TwoTiles },
                    Path = TemplateCoordinator.BlockPath("GroupedTilesBlock/TwoTiles")                   
                     
                },
                new TemplateModel
                {
                    Name = "Five Tiles",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.FiveTiles},
                    Path = TemplateCoordinator.BlockPath("GroupedTilesBlock/FiveTiles")

                },
                new TemplateModel
                {
                    Name = "Faq Tiles",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.ContentAreaTags.FaqTiles},
                    Path = TemplateCoordinator.BlockPath("GroupedTilesBlock/Faqs")

                }
            };
        }
    }
}