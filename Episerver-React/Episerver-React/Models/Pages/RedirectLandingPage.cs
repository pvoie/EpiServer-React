using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

using EPiServer.SpecializedProperties;
using EPiServer.Web;
using Episerver_React.Models.Media;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Redirect Landing Page", GUID = "168319f0-40e7-41aa-9ac0-2198b2bd6f91", Description = "")]
    public class RedirectLandingPage : BasePageData
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
        [UIHint(UIHint.Textarea)]
        public virtual string Description { get; set; }

        [CultureSpecific]
        [Display(
        Name = "CallOutLabel",
        GroupName = SystemTabNames.Content,
        Order = 30)]
        public virtual string CallOutLabel { get; set; }

        [CultureSpecific]
        [Display(
        Name = "CheckBoxLabel",
        GroupName = SystemTabNames.Content,
        Order = 40)]
        public virtual string CheckBoxLabel { get; set; }

        [CultureSpecific]
        [Display(
        Name = "Logo",
        GroupName = SystemTabNames.Content,
        Order = 50)]
        [AllowedTypes(typeof(SiteImage))]
        public virtual ContentReference Logo { get; set; }

    }
}