using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Episerver_React.Models.Blocks;
using EPiServer.Web;
using Episerver_React.Models.Media;
using System.Collections.Generic;
using Episerver_React.Models.Properties;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer;

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
        Name = "CallOut Label",
        GroupName = SystemTabNames.Content,
        Order = 30)]
        public virtual string CallOutLabel { get; set; }

        [CultureSpecific]
        [Display(
        Name = "CheckBox Label",
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

        [CultureSpecific]
        [Display(
        Name = "Campaign Redirect",
        GroupName = SystemTabNames.Content,
        Order = 60)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<QueryStringUrl>))]
        public virtual IList<QueryStringUrl> QueryStringUrls { get; set; }

        [CultureSpecific]
        [Display(
        Name = "Default Campaign Url",
        GroupName = SystemTabNames.Content,
        Order = 65)]
        [Required]
        public virtual Url DefaultCampaignUrl { get; set; }



        [CultureSpecific]
        [Display(
        Name = "Info Label",
        GroupName = SystemTabNames.Content,
        Order = 70)]
        public virtual string InfoLabel { get; set; }

        
        [Display(
        Name = "Extra CTAs",
        GroupName = SystemTabNames.Content,
        Order = 80)]
        [AllowedTypes(new[] { typeof(LinkItem) })]
        public virtual ContentArea ExtraCtas { get; set; }

    }
}