using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Episerver_React.Models.Media;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "LogoCollectionBlock", GUID = "ee66d63f-58b3-4d16-ac8b-bd5193f7b9ac", Description = "")]
    public class LogoCollectionBlock : BlockData
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


        [CultureSpecific]
        [Display(
           Name = "Disclaimer",
           GroupName = SystemTabNames.Content,
           Order = 30)]
        [UIHint(UIHint.Textarea)]
        public virtual string Disclaimer { get; set; }


        [CultureSpecific]
        [Display(
           Name = "Logos",
           GroupName = SystemTabNames.Content,
           Order = 40)]
        [AllowedTypes(new[] {typeof(SiteImage), typeof(LinkItem) })]
        public virtual ContentArea Logos { get; set; }


    }
}