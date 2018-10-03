using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Episerver_React.Models.Pages;

namespace Episerver_React.Controllers
{
    public class ResultsPageController : BasePageController<ResultsPage>
    {
        public ActionResult Index(ResultsPage currentPage)
        {

            //Searching 

            var searchTerm = Request.QueryString["filters"] ?? Request.QueryString["q"];

            var searchPages = SearchClient.Instance.Search<ArticlePage>()                
                .For(searchTerm)
                .InField(x => x.Categories)
                .FilterForVisitor()
                .GetContentResult();

            var resultsPage = searchPages.TotalMatching.ToString();

            //var result = resultsPage.GetContentResult();

            //var res = result.TermsFacetFor(x => x.ViewName).Terms;

            var model = CreateModelWithSettings(currentPage);
            model.Results = resultsPage.Split(',');
            
            return View(string.Format("~/Views/Pages/{0}/Index.cshtml",currentPage.ViewName),model);
        }
    }
}