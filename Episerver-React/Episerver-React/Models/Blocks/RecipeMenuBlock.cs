using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Episerver_React.Models.Pages;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "RecipeMenuBlock", GUID = "19f975db-c262-4b34-9e5f-99ac6e121674", Description = "")]
    public class RecipeMenuBlock : BaseBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Dropdown Label",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string DropdownLabel { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Search Placeholder",
          GroupName = SystemTabNames.Content,
          Order = 20)]
        public virtual string SearchPlaceholder { get; set; }





    }
}