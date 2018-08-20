using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Models
{
    public class PaginationModel
    {
        public string Area { get; set; }
        public string PageName { get; set; }
        public int ItemsOnPage { get; set; }
    }
}