﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Episerver_React.Business.Extensions;
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


        [CultureSpecific]
        [Display(
           Name = "Has back button",
           GroupName = SystemTabNames.Content,
           Order = 60)]
        public virtual bool BackButton { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            BackButton = false;
        }

        public string Categories
        {
            get
            {
                return string.Join(",", this.GetTextForCategories());
            }
        }

        public IEnumerable<string> CategoryMenu
        {
            get { return this.GetTextForCategories(); }
        }


    }
}