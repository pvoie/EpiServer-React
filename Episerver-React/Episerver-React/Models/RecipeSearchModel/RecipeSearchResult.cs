using Episerver_React.Models.Pages;
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
        }

        public List<RecipeSearchItem> Items { get; set; }
    }
}