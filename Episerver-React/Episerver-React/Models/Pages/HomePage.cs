using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Episerver_React.Models.Blocks;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Home Page",
        GUID = "de042715-343b-47c6-bedf-58810a8b8669",
        Description = "Website's Home page")]
    public class HomePage : BasePageData
    {
        [Display(
            Name = "Main Content",
            Order = 1,
            GroupName = SystemTabNames.Content)]
        public virtual ContentArea MainContent { get; set; }

        [Display(
           Name = "Site Settings",
           Order = 100,
           GroupName = SystemTabNames.Settings)]
        [AllowedTypes(typeof(SiteSettingsBlock))]
        public virtual ContentReference SiteSettings { get; set; }
    }
}