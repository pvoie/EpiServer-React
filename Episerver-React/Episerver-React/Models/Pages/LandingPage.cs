using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Media;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Landing Page", GUID = "441e0d3f-f525-4021-88e4-67d7c1b62bff", Description = "")]
    public class LandingPage : BasePageData
    {

        [CultureSpecific]
        [Display(
            Name = "Hero Banner Background",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [AllowedTypes(typeof(SiteImage))]
        public virtual ContentReference HeroBackground { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Hero Banner Logo",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(SiteImage))]
        public virtual ContentReference HeroLogo { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Banners",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [AllowedTypes(typeof(CallToActionCardA))]
        public virtual ContentArea Banners { get; set; }

    }
}