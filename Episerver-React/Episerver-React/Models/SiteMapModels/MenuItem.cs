using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Models.SiteMapModels
{
    public class MenuItem
    {
        public string Name { get; set; }
        public ContentReference ContentLink { get; set; }
        public IEnumerable<MenuItem> Children { get; set; }
    }
}