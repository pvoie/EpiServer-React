using Episerver_React.Models.Blocks;
using Episerver_React.Models.Pages;
using System.Collections.Generic;

namespace Episerver_React.Models.Interfaces
{
    /// <summary>
    /// Groups custom properties for page view models
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPageViewModel<out T> where T : BasePageData
    {
        T CurrentPage { get; }

        SiteSettingsBlock SiteSettings { get; set; }

        string HeaderHtml { get; set; }

        string FooterHtml { get; set; }

        IEnumerable<string> Results { get; set; }
    }
}
