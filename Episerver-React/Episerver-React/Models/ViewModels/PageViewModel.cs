using Episerver_React.Models.Blocks;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;

namespace Episerver_React.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : BasePageData
    {
        public PageViewModel()
        {
        }

        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        /// <summary>
        /// Page that needs to be rendered
        /// </summary>
        public T CurrentPage { get; protected set; }

        public string HeaderHtml { get; set; }

        public string FooterHtml { get; set; }

        public SiteSettingsBlock SiteSettings { get; set; }
    }

    public static class PageViewModel
    {
        public static PageViewModel<T> Create<T>(T page) where T : BasePageData
        {
            return new PageViewModel<T>(page);
        }
    }
}