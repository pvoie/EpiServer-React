using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "FaqsBlock", GUID = "fa99b34e-f9d2-4bf2-b748-3564c7aaa8f5", Description = "")]
    public class FaqsBlock : BaseBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
         Name = "Questions Section",
         GroupName = SystemTabNames.Content,
         Order = 20)]
        [AllowedTypes(new[] { typeof(QuestionBlock) })]
        public virtual ContentArea Questions { get; set; }

    }
}