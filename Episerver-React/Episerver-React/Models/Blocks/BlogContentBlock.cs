using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Interfaces;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Blog Content Block", GUID = "d81d96cb-1ca8-400e-8ea6-10d3dad382aa", Description = "Content block for blog pages")]
    public class BlogContentBlock : BaseBlockData, ISpecialRenderingContent
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
            Name = "Images",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [AllowedTypes(new[] { typeof(LinkItem) })]
        public virtual ContentArea Images { get; set; }

        public string[] SupportedDisplayOptions
        {
            get
            {
                return new[]
                {
                    GlobalSettings.ContentAreaTags.BottomImage,
                    GlobalSettings.ContentAreaTags.TopImage,
                    GlobalSettings.ContentAreaTags.RightImage
                };
            }
        }

      
    }
}