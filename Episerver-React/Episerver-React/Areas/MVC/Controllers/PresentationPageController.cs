using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Episerver_React.Areas.MVC.Models;
using System.Data.Entity;
using Episerver_React.Areas.MVC.Models.ViewModels;

namespace Episerver_React.Areas.MVC.Controllers
{
    public class PresentationPageController : Controller
    {
        EPiServerDB _db = new EPiServerDB();

        //[OutputCache(Duration = 60)]
        // GET: AboutPage
        public ActionResult Index()
        {
            using (var context = new EPiServerDB())
            {
                var model = new GeneralViewModel();
                model.PageInfo = new PaginationViewModel();
                
                //Get the newest 5 products
                model.Items = context.Products.OrderBy(p=>p.Id).Skip(Math.Max(0, context.Products.Count() - 5)).ToList();
                
                model.Items.Reverse();
                foreach (Product item in model.Items)
                {
                    //Get the promotion for each product
                    item.Promotion = context.Promotions
                                               .Where(pr => pr.Id == context.Products
                                                                            .Where(p => p.Id == item.Id)
                                                                            .FirstOrDefault().Promotion.Id)
                                                                            .FirstOrDefault();
                    //Get the Image for each product
                    item.Picture = context.Pictures
                                            .Where(pr => pr.Id == context.Products
                                                                         .Where(p => p.Id == item.Id)
                                                                         .FirstOrDefault().Picture.Id)
                                                                         .FirstOrDefault();
                }




                //Cookie based recommendation
                if (Request["mycookie"] != null)
                {
                   
                    if (String.IsNullOrWhiteSpace(Request.Cookies["mycookie"].Value))
                    {
                        model.Recommended = context.Products.ToPage(6, 0);
                        model.PageInfo.CurrentPage = 0;
                        model.PageInfo.ItemsOnPage = 6;
                        
                        return View(model);
                    }
                    else
                    {
                        model.Recommended = context.Products.Search(Request.Cookies["mycookie"].Value).ToList();
                        model.PageInfo.CurrentPage = 0;
                        model.PageInfo.ItemsOnPage = 6;
                        ViewBag.Message = "Some recommend products for you: ";

                        return View(model);

                    }

                }
                else
                {
                    model.Recommended = context.Products.ToPage(6, 0);
                    model.PageInfo.CurrentPage = 0;
                    model.PageInfo.ItemsOnPage = 6;

                    return View(model);

                }


                

            }

        }

        public ActionResult Search(string SearchString, int pageIndex=0)
        {
            if (String.IsNullOrWhiteSpace(SearchString))
            {
                return RedirectToAction("Index");
            }
            else
            {
                var model = new GeneralViewModel();
                model.PageInfo = new PaginationViewModel();

                model.Items = _db.Products.Search(SearchString);

                if (model.Items.Count() > 0)
                {

                    model.PageInfo.ItemsOnPage = 12;
                    return View("~/Areas/MVC/Views/Products/Index.cshtml", model);
                }
                else
                {
                    TempData["EMPTY"] = "No results have been found";
                    return RedirectToAction("Index","Products");

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


        public ActionResult Menu()
        {
            using (var context = new EPiServerDB())
            {
                var menu = new List<MenuViewModel>();
                
                var categories = context.Categories.ToList();

                foreach (var category in categories)
                {
                    var menuNode = new MenuViewModel();
                    menuNode.Action = "Category";
                    menuNode.Controller = "Products";
                    menuNode.IsAction = true;
                    menuNode.Title = category.Name;
                    var submenuList = new List<MenuViewModel>();

                    foreach (var subCategory in category.SubCategories)
                    {
                        

                        submenuList.Add(new MenuViewModel()
                        {
                            Action = "Subcategory",
                            Controller = "Products",
                            IsAction = true,
                            Title = subCategory.Name
                        });

                    }
                    menuNode.SubMenu = submenuList;
                    menu.Add(menuNode);
                }
                return PartialView("~/Areas/MVC/Views/Shared/Partial/_MenuV2.cshtml", menu);
            }

           

        }
    }
}
        /* public ActionResult Search()
         {
             return RedirectToAction("Index","");
         }*/

