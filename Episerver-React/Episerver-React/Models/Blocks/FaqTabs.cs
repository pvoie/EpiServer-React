using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "FAQ Tabs", GUID = "d16f7ee7-a318-4710-9100-98358e6360a2", Description = "Display multiple FAQs tabs")]
    public class FaqTabs : BaseBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "FAQs",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [AllowedTypes(new[] { typeof(FaqsBlock) })]
        public virtual ContentArea Faqs { get; set; }

    }
}