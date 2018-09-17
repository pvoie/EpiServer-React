using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Episerver_React.Models.Media;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Call To Action Block", GUID = "1b9731ff-9325-48d7-81c5-1b426c0f70b1", Description = "")]
    public class CallToActionCardA : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Background Image",
          GroupName = SystemTabNames.Content,
          Order = 20)]
        [Required]
        [AllowedTypes(typeof(SiteImage))]
        public virtual ContentReference BgImage { get; set; }

       
        [Display(
          Name = "Link Item",
          GroupName = SystemTabNames.Content,
          Order = 30)]      
        
        public virtual LinkItem Link { get; set; }

    }
}