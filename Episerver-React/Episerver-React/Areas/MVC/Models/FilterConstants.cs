using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Areas.MVC.Models
{

    public static class FilterConstants
    {
        public static readonly string[] MenSizes = { "Select size", "40", "41", "42", "43", "44", "45", "46" };
        public static readonly string[] WomenSizes = { "35", "36", "37", "38", "39", "40" };
        public static readonly string[] KidsSizes = { "34", "35", "36", "37" };
        public static readonly string[] Categories = { "Select category", "Men", "Women", "Kids" };
    }
}