using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Episerver_React.Models;

namespace Episerver_React.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            //using (var context = new EPiServerDB())
            //{
            //    var pageSettings = new MenuViewModel();
            //    pageSettings.Menu = context.Categories.ToList();

            //    return PartialView("~/Views/Shared/Partial/_Menu.cshtml", pageSettings);

            //}

            return View();
        }
    }
}