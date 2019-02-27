using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Results Page", GUID = "237f466e-ea40-4c1c-94de-02f7dbd2eb0b", Description = "")]
    public class ResultsPage : BasePageData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",           
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual String Heanding { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Description",
          GroupName = SystemTabNames.Content,
          Order = 20)]
        [UIHint(UIHint.Textarea)]
        public virtual String Description { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Items per page",
          GroupName = SystemTabNames.Content,
          Order = 30)]
        public virtual int PageSize { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Not found message",
          GroupName = SystemTabNames.Content,
          Order = 40)]
        public virtual string NotFoundMessage { get; set; }

        [CultureSpecific]
        [Display(
          Name = "Has back button",
          GroupName = SystemTabNames.Content,
          Order = 50)]
        public virtual bool BackButton { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            BackButton = false;
        }


    }
}