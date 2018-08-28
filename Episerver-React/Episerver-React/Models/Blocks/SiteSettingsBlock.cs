using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Episerver_React.Business.Settings;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Site Settings Block",
        GUID = "081045ef-2ae0-4bf7-b6fc-40d99506fe50",
        Description = "Block with general site settings")]
    public class SiteSettingsBlock : BaseBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Footer Disclaimer",
            Description = "Footer Disclaimer",
            GroupName = SystemTabNames.Settings,
            Order = 10)]
        public virtual string FooterDisclaimer { get; set; }

        [Display(
           Name = "Header",
           Order = 20,
           GroupName = ContentEditorTabs.Header)]
        public virtual HtmlInjectedBlock HeaderBlock { get; set; }

        [Display(
            Name = "Footer",
            Order = 30,
            GroupName = ContentEditorTabs.Footer)]
        public virtual HtmlInjectedBlock FooterBlock { get; set; }
    }
}