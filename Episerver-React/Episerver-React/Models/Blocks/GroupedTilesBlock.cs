using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "GroupedTilesBlock", GUID = "12a7f57c-6e75-4436-9b42-b1807c0fa814", Description = "")]
    public class GroupedTilesBlock : BaseBlockData
    {
        
        [CultureSpecific]
        [Display(
           Name = "Tiles",
           GroupName = SystemTabNames.Content,
           Order = 20)]
        [AllowedTypes(typeof(CallToActionCard))]
        public virtual ContentArea Tiles { get; set; }

    }
}