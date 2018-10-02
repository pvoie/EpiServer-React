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


            var searchTerm = Request.QueryString["filters"]; /*?? Request.QueryString["q"];*/

            var searchResult = SearchClient.Instance.Search<ArticlePage>();
            searchResult = searchResult.For(searchTerm).FilterForVisitor();

            var results = searchResult.TermsFacetFor(x => x.ViewName).GetContentResult();

            var model = CreateModelWithSettings(currentPage);
            
            return View(string.Format("~/Views/Pages/{0}/Index.cshtml",currentPage.ViewName),model);
        }
    }
}