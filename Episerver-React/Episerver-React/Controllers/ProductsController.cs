using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Services.Description;
using Episerver_React.Models;
using Sgml;

namespace Episerver_React.Controllers
{
    public class ProductsController : Controller
    {
        
        // GET: Products
        public ActionResult Index()
        {

            using (var context = new EPiServerDB())
            {
                IEnumerable<Product> model = context.Products.ToList();


                return View(model.Reverse());
            }
        
          


                
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            using (var context = new EPiServerDB())
            {
                if (context.Products.Any(p => p.Id == id))
                {
                    var product = context.Products.FirstOrDefault(p => p.Id == id);
                    return View(product);
                }
                else
                {
                    return new HttpNotFoundResult("Product you've requested does not exist");
                }
               
            }
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            
            
                using (var context = new EPiServerDB())
                {
                    if (ModelState.IsValid)
                    {
                    context.Products.Add(product);
                    context.SaveChanges();
                    var message = "Your product has been created";
                    TempData["OK"] = message;
                    return RedirectToAction("Index");
                    }
                return View();
                                                  

                }
                 
          }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {

            using (var context = new EPiServerDB())
            {
                IEnumerable<Product> model = context.Products.ToList();


                return View(model.FirstOrDefault(p => p.Id==id));
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            using (var context = new EPiServerDB())
            {
                if (ModelState.IsValid)
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    var message = "Your product has been updated";
                    TempData["OK"] = message;
                    return RedirectToAction("Index");
                }
                return View();

                
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {

            using (var context = new EPiServerDB())
            {

                    var product = context.Products.Find(id);
                    context.Entry(product).State = EntityState.Deleted;
                    context.SaveChanges();

                    TempData["RED"] = "Your product has been deleted";

                    return RedirectToAction("Index");
                
                
            }
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    
        

    }
}
