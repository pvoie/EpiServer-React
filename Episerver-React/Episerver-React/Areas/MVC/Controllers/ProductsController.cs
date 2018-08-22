using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
//using System.Web.Services.Description;
using Episerver_React.Areas.MVC.Models;
using Episerver_React.Areas.MVC.Models.ViewModels;
using Episerver_React.App_Start;


namespace Episerver_React.Areas.MVC.Controllers
{
    public class ProductsController : Controller
    {

        // GET: Products
        [OutputCache(CacheProfile = "ClientResourceCache", VaryByHeader ="Accept-Language")]
        public ActionResult Index(int pageIndex = 0)
        {

            using (var context = new EPiServerDB())
            {
                IEnumerable<Product> items = context.Products.ToPage(12, pageIndex);
                foreach (var item in items)
                {
                    item.Promotion = context.Promotions
                                            .Where(pr => pr.Id == context.Products
                                                                         .Where(p => p.Id == item.Id)
                                                                         .FirstOrDefault().Promotion.Id)
                                                                         .FirstOrDefault();
                }

                //getting the number of items per page
                var itemsOnPage = PaginationConfig.Rules.Where(p => p.PageName.Contains("Products/Index"))
                                                            .FirstOr(PaginationConfig.Rules.First(x => x.PageName.Contains("Default")))
                                                            .ItemsOnPage;


                var model = new GeneralViewModel
                {
                    Items = items,
                    PageInfo = new PaginationViewModel
                    {
                        ItemsOnPage = itemsOnPage,
                        Pages = context.Products.Count().NumberOfPages(itemsOnPage),
                        CurrentPage = pageIndex
                       
                    }

                };              
               Response.Cache.SetOmitVaryStar(true);
                return View(model);
            }
        }

        // GET: Products/Details/5
        public ActionResult Details(int id=0)
        {
            using (var context = new EPiServerDB())
            {
                if (context.Products.Any(p => p.Id == id))
                {
                    Product product = context.Products.Where(p=>p.Id == id).Single();
                    var promo = context.Promotions.Where(pr=>pr.Id == context.Products.Where(p=>p.Id==id).FirstOrDefault().Promotion.Id).FirstOrDefault();

                    product.Promotion = promo;
                    
                    return View(product);
                }
                else
                {
                    return new HttpNotFoundResult("Product you've requested does not exist");
                }
               
            }
        }

        public ActionResult Category(string category, int pageIndex = 0)
        {
            using (var context = new EPiServerDB())
            {
                var products = context.Products.Where(p => p.SubCategory.Category.Name==category).ToList();
                foreach (var item in products)
                {
                    item.Promotion = context.Promotions.Where(pr => pr.Id == context.Products.Where(p => p.Id == item.Id).FirstOrDefault().Promotion.Id).FirstOrDefault();
                }

                var model = new GeneralViewModel
                {
                    Items = products.OrderBy(p => p.Id).Skip(pageIndex * 12).Take(12),
                    PageInfo = new PaginationViewModel
                    {
                        Pages = products.Count.NumberOfPages(12),
                        CurrentPage = pageIndex,
                        ItemsOnPage = 12
                       
                    }

                };

                return View("~/Areas/MVC/Views/Products/Index.cshtml", model);
            }

        }

        public ActionResult Subcategory(string category,string subcategory, int pageIndex = 0)
        {
            using (var context = new EPiServerDB())
            {
                var products = context.Products.Where(p => p.SubCategory.Name==subcategory&&p.SubCategory.Category.Name==category).ToList();
                foreach (var item in products)
                {
                    item.Promotion = context.Promotions.Where(pr => pr.Id == context.Products.Where(p => p.Id == item.Id).FirstOrDefault().Promotion.Id).FirstOrDefault();
                }

                var model = new GeneralViewModel
                {
                    Items = products.OrderBy(p => p.Id).Skip(pageIndex * 12).Take(12),
                    PageInfo = new PaginationViewModel
                    {
                        Pages = products.Count.NumberOfPages(12),
                        CurrentPage = pageIndex,
                        ItemsOnPage = 12
                    }
                };
                
                return View("~/Areas/MVC/Views/Products/Index.cshtml", model);

            }
                        
        }
        

        public ActionResult AdvancedSearch(SearchModel searchModel, int pageIndex = 0)
        {
            using (var context = new EPiServerDB())
            {
                //verify the unselected fields and set "" value for them
                foreach (PropertyInfo prop in typeof(SearchModel).GetProperties() )
                {
                    if (prop.GetValue(searchModel)==null)
                    {
                        prop.SetValue(searchModel, "");
                    }

                    if (prop.GetValue(searchModel).ToString().Contains("Select"))
                    {
                        prop.SetValue(searchModel, "");
                    }

                    if (prop.GetValue(searchModel).ToString().Contains("-"))
                    {
                        prop.SetValue(searchModel, "");
                    }

                    
                }
                
                //get the products matching the search fields
                var products = context.Products.Where(p => p.SubCategory.Category.Name.Contains(searchModel.Category)).Where(p => p.Description.Contains(searchModel.Size)).ToList();

                foreach (var item in products)
                {
                    item.Promotion = context.Promotions.Where(pr => pr.Id == context.Products
                                                                                    .Where(p => p.Id == item.Id)
                                                                                    .FirstOrDefault().Promotion.Id)
                                                                                    .FirstOrDefault();
                }

                var model = new GeneralViewModel
                {
                    Items = products.OrderBy(p => p.Id).Skip(pageIndex * 12).Take(12),
                    PageInfo = new PaginationViewModel
                    {
                        Pages = products.Count.NumberOfPages(12),
                        CurrentPage = pageIndex,
                        ItemsOnPage = 12,
                        Model = searchModel
                    }

                };
                
                return View("~/Areas/MVC/Views/Products/Index.cshtml", model);

            }

            
        }

    }
}
