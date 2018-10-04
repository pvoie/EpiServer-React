using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Models.RecipeSearchModel
{
    public class RecipeSearchItem
    {
        public int OriginalId {get;set;}

        public string Heading { get; set; }

        public ContentReference PageLink { get; set; }

        public ContentReference ImageLink { get; set; }


    }
}