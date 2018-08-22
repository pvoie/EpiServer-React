using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Areas.MVC.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string SmallImage { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }
        //public Product Product { get; set; }
    }
}