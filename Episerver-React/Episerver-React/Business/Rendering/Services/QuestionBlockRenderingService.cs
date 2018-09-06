using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Rendering.Services
{
    public class QuestionBlockRenderingService : IContentRenderingService<QuestionBlock>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>
            {
                 new TemplateModel
                {
                    Name = "Question",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.RenderingTags.QuestionItem },
                    Path = TemplateCoordinator.BlockPath("FaqsBlock/Question")
                }
            };
        }
    }
}