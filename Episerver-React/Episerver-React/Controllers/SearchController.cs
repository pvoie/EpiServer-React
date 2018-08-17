using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Episerver_React.Models;

namespace Episerver_React.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        //[HttpPost]
        public JsonResult Autocomplete(string searchString)
        {
            var context = new EPiServerDB();
            
                var products = context.Products.Where(p => p.Name.Contains(searchString)).Take(5).ToList();

            //return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return Json(products, JsonRequestBehavior.AllowGet);


            
        }
    }
}