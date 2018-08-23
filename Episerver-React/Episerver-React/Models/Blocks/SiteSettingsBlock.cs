using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "SiteSettingsBlock", GUID = "081045ef-2ae0-4bf7-b6fc-40d99506fe50", Description = "")]
    public class SiteSettingsBlock : BaseBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Footer Disclaimer",
            Description = "Footer Disclaimer",
            GroupName = SystemTabNames.Settings,
            Order = 1)]
        public virtual string FooterDisclaimer { get; set; }

    }
}