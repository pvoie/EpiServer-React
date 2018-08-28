using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Html Injected Block",
        GUID = "be830464-078a-4ff8-a521-b24703a9f392",
        Description = "Loads and injects HTML inside the page from an external source")]
    public class HtmlInjectedBlock : BaseBlockData
    {
        [CultureSpecific]
        [Display(
             Name = "Source URL",
             Order = 10,
             GroupName = SystemTabNames.Content)]
        [Url]
        public virtual string SourceUrl { get; set; }

        [Display(
            Name = "Request Timeout (seconds)",
            Order = 20,
            GroupName = SystemTabNames.Content)]
        [Range(5, 240)]
        public virtual int RequestTimeoutSeconds { get; set; }

        [Display(
            Name = "Cache Duration (hours)",
            Order = 30,
            GroupName = SystemTabNames.Content,
            Description = "Set 0 to disable caching")]
        [Range(0, 24)]
        public virtual double CacheDurationHours { get; set; }
    }
}