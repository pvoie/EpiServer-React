using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "ContentPage", GUID = "5d1aa782-b7ac-4d0c-ba0c-c919d25a39fa", Description = "Simple Content Page")]
    public class ContentPage : BasePageData
    {

        [CultureSpecific]
        [Display(
            Name = "Main Content",            
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual ContentArea MainContent { get; set; }

    }
}