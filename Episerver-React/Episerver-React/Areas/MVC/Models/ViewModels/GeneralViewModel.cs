using System;
using System.Collections.Generic;

namespace Episerver_React.Areas.MVC.Models.ViewModels
{
    public class GeneralViewModel
    {
        public PaginationViewModel PageInfo { get; set; }
        
        public IEnumerable<Object> Items { get; set; }

        public IEnumerable<Product> Recommended { get; set; }

        


        
    }
}