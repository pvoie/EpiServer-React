using Episerver_React.Models.Blocks;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Models.SiteMapModels
{
    public class SiteMapViewModel<T> : IPageViewModel<T> where T:SiteMapPage
    {
        public SiteMapViewModel(T currentPage)
        {
            CurrentPage = currentPage;
            SiteMap = new SiteMapView();
        }
       
        public T CurrentPage { get; set; }
        public SiteMapView SiteMap { get; set; }
        public SiteSettingsBlock SiteSettings { get; set; }
        public string HeaderHtml { get; set; }
        public string FooterHtml { get; set; }
    }
}