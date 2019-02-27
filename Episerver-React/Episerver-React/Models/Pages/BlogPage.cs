using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Episerver_React.Models.Blocks;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Blog Page", GUID = "dc4e2aa4-cca4-4beb-ab96-b8d6b9e71b60", Description = "A page that contains blog posts")]
    public class BlogPage : BasePageData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",            
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heanding { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Content blocks",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(new[] { typeof(BlogContentBlock) })]
        public virtual ContentArea ContentBlocks { get; set; }


        [CultureSpecific]
        [Display(
           Name = "Has back button",
           GroupName = SystemTabNames.Content,
           Order = 30)]
        public virtual bool BackButton { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            BackButton = false;
        }
    }
}