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
            using (var context = new EPiServerDB() )
            {
                if (Request["mycookie"] != null)
                {
                    if (String.IsNullOrWhiteSpace(Request.Cookies["mycookie"].Value))
                    {
                        IEnumerable<Product> model = context.Products.ToPage(6, 0);
                        ViewBag.CurrentPage = 0;
                        ViewBag.ItemsOnPage = 6;

                        return View(model);
                    }
                    else
                    {
                        IEnumerable<Product> model = context.Products.Search(Request.Cookies["mycookie"].Value).ToList();
                        ViewBag.CurrentPage = 0;
                        ViewBag.ItemsOnPage = 6;
                        ViewBag.Message = "Some recommend products for you: ";

                        return View(model);

                    }

                }
                else
                {
                    IEnumerable<Product> model = context.Products.ToPage(6, 0);
                    ViewBag.CurrentPage = 0;
                    ViewBag.ItemsOnPage = 6;

                    return View(model);

                }



            }
                
        }

        public ActionResult Search(string SearchString, int pageIndex)
        {
            if (String.IsNullOrWhiteSpace(SearchString))
            {
                return RedirectToAction("Index");
            }
            else
            {

                var model = _db.Products.Search(SearchString);

                if (model.Count() > 0)
                {

                    ViewBag.ItemsOnPage = 12;
                    return View("~/Views/PresentationPage/Index.cshtml", model);
                }
                else
                {
                    TempData["EMPTY"] = "No results have been found";
                    return RedirectToAction("Index");

                }
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