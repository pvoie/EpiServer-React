using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Episerver_React.Models.Media;
using Episerver_React.Models.Interfaces;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Link Item", GUID = "cabeaf7f-9cd1-4d3f-823a-f055135f5eb0", Description = "")]
    public class LinkItem : BaseBlockData
    {        
        [Display(
           Name = "URL",
           Order = 10,
           GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        public virtual Url Link { get; set; }

        [Display(
            Name = "Text",
            Order = 20,
            GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        public virtual string Text { get; set; }

        [Display(
            Name = "Title",
            Order = 30,
            GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(
           Name = "Image",
           Order = 40,
           GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        [AllowedTypes(typeof(SiteImage))]
        public virtual ContentReference Image { get; set; }

        
    }
}