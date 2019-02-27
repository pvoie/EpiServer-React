﻿using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Episerver_React.Business.Settings;
using Episerver_React.Models.Pages;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Site Settings Block", GUID = "046c16a7-c9f4-497d-998d-c19d134ca030", Description = "")]
    public class SiteSettingsBlock : BlockData
    {
        [CultureSpecific]
        [Display(
                   Name = "Footer Disclaimer",
                   Description = "Footer Disclaimer",
                   GroupName = SystemTabNames.Settings,
                   Order = 10)]
        public virtual string FooterDisclaimer { get; set; }

        [Display(
           Name = "Header",
           Order = 20,
           GroupName = ContentEditorTabs.Header)]
        public virtual HtmlInjectedBlock HeaderBlock { get; set; }

        [Display(
            Name = "Footer",
            Order = 30,
            GroupName = ContentEditorTabs.Footer)]
        public virtual HtmlInjectedBlock FooterBlock { get; set; }

        #region Menu               

        [Display(
         Name = "Menu",
         Order = 40,
         GroupName = SystemTabNames.Content)]
        [AllowedTypes(typeof(RecipeMenuBlock))]       
        public virtual ContentReference MenuItem { get; set; }


        [Display(
         Name = "Home Landing Page",
         Order = 50,
         GroupName = SystemTabNames.Content)]        
        public virtual PageReference HomeLandingPage { get; set; }

        [CultureSpecific]
        [Display(
         Name = "Search Page Link",
         GroupName = SystemTabNames.Content,
         Order = 60)]
        [AllowedTypes(new[] { typeof(BasePageData), typeof(LinkItem) })]
        public virtual ContentReference RecipeSearchPage { get; set; }

        [CultureSpecific]
        [Display(
         Name = "Site Map Page",
         GroupName = SystemTabNames.Content,
         Order = 60)]
        [AllowedTypes(new[] { typeof(SiteMapPage) })]
        public virtual ContentReference SiteMapPage { get; set; }

        #endregion


    }
}