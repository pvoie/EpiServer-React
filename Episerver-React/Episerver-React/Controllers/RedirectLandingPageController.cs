using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Episerver_React.Models.Pages;

namespace Episerver_React.Controllers
{
    public class RedirectLandingPageController : BasePageController<RedirectLandingPage>
    {
        public ActionResult Index(RedirectLandingPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = CreateModelWithSettings(currentPage);
            
            return View(string.Format("~/Views/Pages/{0}/Index.cshtml", currentPage.ViewName), model);
        }
    }
}