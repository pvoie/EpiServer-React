using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Episerver_React.Models.Media
{
    [ContentType(DisplayName = "SiteImage", GUID = "d5afc7d3-82e7-4800-a9e2-beff82c1e52f", Description = "")]
    [MediaDescriptor(ExtensionString = "jpeg,png,jpg,jpe,ico,gif,bmp,svg")]
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