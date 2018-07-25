using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Episerver_React.Models;
using System.Data.Entity;

namespace Episerver_React.Controllers
{
    public class PresentationPageController : Controller
    {
        EPiServerDB _db = new EPiServerDB();
        
        //[OutputCache(Duration = 60)]
        // GET: AboutPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string SearchString)
        {
            if (SearchString != "") {
                var model = _db.Products.AsQueryable().Where(p => p.Name.Contains(SearchString)).ToList();
                                
                if(model.Count > 0)
                {
                    return View("Index", model);
                }
                else
                {
                    TempData["EMPTY"] = "No results have been found";
                    return RedirectToAction("Index");

                }
              }
            else
            {
                return RedirectToAction("Index");
            }
            
        }


        // GET: AboutPage
        public ActionResult Products()
        {
            return RedirectToAction("Index", "Products");
        }

        
        // GET: AboutPage
        public ActionResult About()
        {
            return View();
        }


       /* public ActionResult Search()
        {
            return RedirectToAction("Index","");
        }*/


    }
}