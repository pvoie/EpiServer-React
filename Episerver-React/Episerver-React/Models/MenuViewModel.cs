using System.Collections.Generic;

namespace Episerver_React.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool IsAction { get; set; }
        public string Link { get; set; }
        public List<MenuViewModel> SubMenu { get; set; }
        
    }
}