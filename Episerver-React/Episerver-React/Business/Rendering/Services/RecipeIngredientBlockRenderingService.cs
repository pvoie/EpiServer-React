using EPiServer.DataAbstraction;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Rendering.Services
{
    public class RecipeIngredientBlockRenderingService : IContentRenderingService<RecipeIngredientBlock>
    {
        public IEnumerable<TemplateModel> GetAvailableTemplates()
        {
            return new List<TemplateModel>
            {
                new TemplateModel
                {
                    Name = "Recipe Ingredient Template",
                    Inherit = false,
                    AvailableWithoutTag = false,
                    Default = false,
                    Tags = new[] { GlobalSettings.RenderingTags.RecipeIngredientTemplate },
                    Path = TemplateCoordinator.BlockPath("RecipeIngredient/RecipeIngredientBlock")
                }
            };
        }
    }
}