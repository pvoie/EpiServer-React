using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Episerver_React.Models.Media
{
    [ContentType(DisplayName = "SiteImage", GUID = "12bb9c82-824c-4d3d-90f5-b0af23b80fb0", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,svg")]
    public class SiteImage : MediaData
    {

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Alternate Text",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string AltText { get; set; }

    }
}