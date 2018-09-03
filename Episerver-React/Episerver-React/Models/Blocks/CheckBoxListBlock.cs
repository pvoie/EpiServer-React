using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "CheckBoxListBlock", GUID = "9233358c-aae1-406a-985a-78a159a58f25", Description = "")]
    public class CheckBoxListBlock : BaseBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Checkbox List",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(LinkItem))]
        public virtual ContentArea CheckboxList{ get; set; }

    }
}