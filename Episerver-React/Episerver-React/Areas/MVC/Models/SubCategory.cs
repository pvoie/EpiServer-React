using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Areas.MVC.Models
{
    public class SubCategory
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}