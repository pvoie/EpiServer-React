using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Site Map Page", GUID = "f3cc807f-f4f9-434a-ac4b-f66bf1d6217d", Description = "This page contains the site map")]
    public class SiteMapPage : BasePageData
    {
        [CultureSpecific]
        [Display(
           Name = "Has back button",
           GroupName = SystemTabNames.Content,
           Order = 10)]
        public virtual bool BackButton { get; set; }
    }
}