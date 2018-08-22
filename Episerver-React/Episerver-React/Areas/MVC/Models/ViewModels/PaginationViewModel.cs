using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Areas.MVC.Models.ViewModels
{
    public class PaginationViewModel
    {
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsOnPage { get; set; }
        public Object Model { get; set; }
    }
}