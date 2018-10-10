using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Campaign Page", GUID = "0c3adbe8-43d2-4bd2-bfb7-c97e4df824ea", Description = "")]
    public class CampaignPage : BasePageData
    {

        [CultureSpecific] 
        [Display(
            Name = "Heading",            
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Recipes",
           GroupName = SystemTabNames.Content,
           Order = 20)]
        [AllowedTypes(typeof(ArticlePage))]
        public virtual ContentArea Recipes { get; set; }

    }
}