using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Recipe Ingredient Block", GUID = "23924fb6-c5ee-4115-8fb6-d3ef240f526f", Description = "")]
    public class RecipeIngredientBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
        Name = "Description",
        GroupName = SystemTabNames.Content,
        Order = 20)]        
        public virtual XhtmlString Description { get; set; }

    }
}