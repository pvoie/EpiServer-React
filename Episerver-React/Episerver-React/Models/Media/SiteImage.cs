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
        
        [Editable(false)]
        [Display(
            Name = "Extension",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string Extension { get; set; }

        [Editable(false)]
        [Display(
           Name = "Mime type",
           GroupName = SystemTabNames.Content,
           Order = 22)]
        public virtual string Mime { get; set; }

        [Editable(false)]
        [Display(
            Name = "Width",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual int Width { get; set; }

        [Editable(false)]
        [Display(
            Name = "Height",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual int Height { get; set; }

    }
}