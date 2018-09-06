using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Episerver_React.Models.Pages;
using Episerver_React.Models.Properties;

namespace Episerver_React.Controllers
{
    public class RedirectLandingPageController : BasePageController<RedirectLandingPage>
    {
        private const string Skip = "skipDHpage";
        private string _dhCmpgn;
        private string _dhUrl;


        public ActionResult Index(RedirectLandingPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */


            _dhCmpgn = Request.QueryString["c"];
            QueryStringUrl item = null; ;
            if (currentPage.QueryStringUrls != null)
            {
                item = currentPage.QueryStringUrls.FirstOrDefault(x => x.QueryString.Equals(_dhCmpgn));
            }
            _dhUrl = item != null ? item.Url.ToString() : currentPage.DefaultCampaignUrl.ToString();
            ViewData["DirectHealthUrl"] = _dhUrl;

            var cookie = string.Format("RLPage_{0}", currentPage.ContentGuid);
            if (Request.Cookies[cookie] != null && Request.Cookies[cookie][Skip] != null && Request.Cookies[cookie][Skip] == "true")
            {
                return Redirect(_dhUrl);
            }


            var model = CreateModelWithSettings(currentPage);
            return View(string.Format("~/Views/Pages/{0}/Index.cshtml", currentPage.ViewName), model);
        }

        public void SetCookie(RedirectLandingPage currentPage)
        {
            var rlpCookie = new HttpCookie(string.Format("RLPage_{0}", currentPage.ContentGuid));
            rlpCookie.Values.Add(Skip, "true");
            rlpCookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(rlpCookie);
        }
    }
}