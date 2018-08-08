using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Episerver_React.Models;

namespace Episerver_React.Models.ViewModels
{
    public class GeneralViewModel
    {
        public PaginationViewModel PageInfo { get; set; }
        
        public IEnumerable<Object> Items { get; set; }
        
    }
}