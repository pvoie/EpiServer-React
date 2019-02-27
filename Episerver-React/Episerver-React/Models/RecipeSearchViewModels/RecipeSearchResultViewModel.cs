using Episerver_React.Models.Blocks;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;
using Episerver_React.Models.RecipeSearchModel;
using Episerver_React.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Models.RecipeSearchViewModels
{
    public class RecipeSearchResultViewModel<T> : IPageViewModel<T> where T : ResultsPage
    {
        public RecipeSearchResultViewModel(T currentPage)
        {
            ResultPage = new RecipeSearchResult();
            CurrentPage = currentPage;
        }

        public RecipeSearchResultViewModel()
        {
            ResultPage = new RecipeSearchResult();
        }

        public RecipeSearchResult ResultPage { get; set; }
        public T CurrentPage {get; protected set;}
        public SiteSettingsBlock SiteSettings { get; set; }
        public string HeaderHtml { get; set; }
        public string FooterHtml { get; set; }    
        

    }
   
}