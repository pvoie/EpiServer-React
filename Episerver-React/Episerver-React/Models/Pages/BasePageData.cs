using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Episerver_React.Business.Settings;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Base Page Data",
        GUID = "27aa6ad2-f3a5-4a35-8812-5ce4e402d1aa",
        Description = "Base page used when no display option or template is needed",
        AvailableInEditMode = false)]
    public abstract class BasePageData : PageData
    {
        #region SEO

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Seo Title",
            Order = 10,
            GroupName = ContentEditorTabs.SeoDetails)]
        public virtual string SeoTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "SEO Description",
            Order = 20,
            GroupName = ContentEditorTabs.SeoDetails)]
        [UIHint(UIHint.Textarea)]
        public virtual string SeoDescription { get; set; }

        [CultureSpecific]
        [Display(
            Name = "SEO Keywords",
            Order = 30,
            GroupName = ContentEditorTabs.SeoDetails)]
        [UIHint(UIHint.Textarea)]
        public virtual string SeoKeywords { get; set; }       
        #endregion
    }
}