using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Episerver_React.Business.Settings
{
    /// <summary>
    /// Custom tabs used inside the editor
    /// </summary>
    [GroupDefinitions]
    public class ContentEditorTabs
    {
        [Display(Order = 80)]
        public const string Header = "Header";

        [Display(Order = 90)]
        public const string Footer = "Footer";

        [Display(Order = 100)]
        public const string SeoDetails = "Seo Details";

        [Display(Order = 110)]
        public const string GoogleAds = "Google Ads";

        [Display(Order = 110)]
        public const string VideoSettings = "Video Settings";
    }
}