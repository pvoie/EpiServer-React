using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Media;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Article Page", GUID = "c42b5d97-8684-44be-b27c-fdcbb5aab6dc", Description = "This page contains details for a specific recipe")]
    public class ArticlePage : BasePageData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",            
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Short description",
           GroupName = SystemTabNames.Content,
           Order = 20)]
        public virtual string ShortDescription { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Image",
           GroupName = SystemTabNames.Content,
           Order = 30)]
        [AllowedTypes(typeof(SiteImage))]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
        Name = "Image Footer",
        GroupName = SystemTabNames.Content,
        Order = 40)]
        public virtual XhtmlString ImageFooter { get; set; }

        [CultureSpecific]
        [Display(
         Name = "Details",
         GroupName = SystemTabNames.Content,
         Order = 50)]
        [AllowedTypes(typeof(RecipeIngredientBlock))]
        public virtual ContentArea Info { get; set; }



    }
}