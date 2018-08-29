using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using EPiBootstrapArea;
using Episerver_React.Models.Media;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Call To Action Card",
        GUID = "a1943638-4222-489f-b203-0ff325e76ff8",
        Description = "Alows you to create a CTA card.")]
   
    public class CallToActionCard : BaseBlockData
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
        public virtual XhtmlString Description { get; set; }

        [Display(
           Name = "Call to Action",
           GroupName = SystemTabNames.Content,
           Order = 30
           )]
        public virtual LinkItem CallToAction { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [AllowedTypes(typeof(SiteImage))]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Sponsor",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual string Sponsor { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Brightcove Video Id",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string VideoId { get; set; }
    }


   
}