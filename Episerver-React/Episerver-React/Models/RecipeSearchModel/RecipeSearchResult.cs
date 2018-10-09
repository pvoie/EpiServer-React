using Episerver_React.Models.Pages;
using Episerver_React.Models.RecipeSearchViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Models.RecipeSearchModel
{
    public class RecipeSearchResult
    {
        public RecipeSearchResult()
        {
            Items = new List<RecipeSearchItem>();
            PaginationViewModel = new PaginationViewModel();
        }

        public List<RecipeSearchItem> Items { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }

        public bool HasMorePages { get; set; }

        public string SuggestedTerm { get; set; }
    }
}