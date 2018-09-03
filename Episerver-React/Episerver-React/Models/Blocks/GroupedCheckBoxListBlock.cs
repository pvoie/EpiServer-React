using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Grouped CheckBox List Block", GUID = "0b033380-8ab1-4296-af51-dd747ed64743", Description = "")]
    public class GroupedCheckBoxListBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Description",
           GroupName = SystemTabNames.Content,
           Order = 20)]
        [UIHint(UIHint.Textarea)]
        public virtual string Description { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Checkbox List",
           GroupName = SystemTabNames.Content,
           Order = 30)]
        [AllowedTypes(typeof(CheckBoxListBlock))]
        public virtual ContentArea CheckboxList { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Buttons",
           GroupName = SystemTabNames.Content,
           Order = 30)]
        [AllowedTypes(typeof(LinkItem))]
        public virtual ContentArea Links { get; set; }

    }
}