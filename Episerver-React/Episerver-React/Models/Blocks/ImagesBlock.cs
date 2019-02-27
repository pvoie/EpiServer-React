using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Episerver_React.Models.Media;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Images Block", GUID = "7bbf5501-6eb9-4b35-a7fb-670ccd4ac9c2", Description = "A block for images")]
    public class ImagesBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Images",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [AllowedTypes(typeof(SiteImage))]
        public virtual ContentArea Images { get; set; }

    }
}