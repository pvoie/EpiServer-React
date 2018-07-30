using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Episerver_React.Models.Pages;

namespace Episerver_React.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : BasePageController<BasePageData>
    {
        public ViewResult Index(BasePageData currentPage)
        {
            //create the page view model with site settings
            var model = CreateModelWithSettings(currentPage);
            HttpCookie myCookie = new HttpCookie("Start");
            myCookie["Fav_brand"] = "Nike";
            myCookie.Expires = DateTime.Now.AddDays(2d);
            Response.Cookies.Add(myCookie);


            return View(string.Format("~/Views/Pages/{0}/Index.cshtml", currentPage.ViewName), model);
        }
    }
}
