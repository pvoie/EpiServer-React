using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Areas.MVC.Models
{
    public class Promotion
    {
        public Promotion()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PercentAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}