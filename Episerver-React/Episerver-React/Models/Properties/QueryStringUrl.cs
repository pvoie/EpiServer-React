using EPiServer;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Episerver_React.Business.Settings;
using System.ComponentModel.DataAnnotations;

namespace Episerver_React.Models.Properties
{
    public class QueryStringUrl
    {
        [Display(Name = "Query String (c)")]
        [CultureSpecific]
        [Required]
        public string QueryString { get; set; }       

        [CultureSpecific]
        [Required]
        [RegularExpression(RegexUrl.Url)]
        public string Url { get; set; }

    }
}