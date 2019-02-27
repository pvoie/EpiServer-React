using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Models.RecipeSearchViewModels
{
    public class PaginationViewModel
    {

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }
    }
}