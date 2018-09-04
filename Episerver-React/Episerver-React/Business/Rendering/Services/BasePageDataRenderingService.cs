using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Rendering.Services
{
    public class BasePageDataRenderingService : IContentRenderingService<BasePageData>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>
            {
                new TemplateModel
                {
                    Name = "Global Navigation Item",
                    Inherit = true,
                    AvailableWithoutTag = true,
                    Default = true,
                    Tags = new[] { GlobalSettings.RenderingTags.GlobalNavigationItem },
                    Path = TemplateCoordinator.PagePartialPath("BasePagePartialLink")
                }
            };
        }
    }
}