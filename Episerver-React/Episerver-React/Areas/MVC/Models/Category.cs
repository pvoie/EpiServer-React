using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Areas.MVC.Models
{
    public class Category
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        
    }
}