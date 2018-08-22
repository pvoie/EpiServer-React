using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Episerver_React.Areas.MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        [Price(ErrorMessage ="Price must be greater than 0")]
        public int Price { get; set; }
        public string Image { get; set; }
        public SubCategory SubCategory { get; set; }
        public Promotion Promotion { get; set; }
        public Picture Picture { get; set; }
    }
}