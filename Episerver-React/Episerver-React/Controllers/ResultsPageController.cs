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
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;
using Episerver_React.Models.ViewModels;
using Episerver_React.Models.Blocks;
using System;
using Episerver_React.Models.RecipeSearchModel;
using Episerver_React.Models.RecipeSearchViewModels;

namespace Episerver_React.Controllers
{
    [TemplateDescriptor(Name = "Recipe Search Controller", Inherited = true, AvailableWithoutTag = true, Default = true)]
    public class ResultsPageController : BasePageController<ResultsPage>
    {
        private readonly IClient _searchClient = SearchClient.Instance;

        public ActionResult Index(ResultsPage currentPage, string filters = "", string q = "")
        {
            var model = CreateRecipeSearchModelWithSettings(currentPage) as RecipeSearchResultViewModel<ResultsPage>;

            model.ResultPage = RecipeSearch(filters, q);

            return View(string.Format("~/Views/Pages/{0}/Index.cshtml", currentPage.ViewName), model);
        }


        #region Search

        private RecipeSearchResult RecipeSearch(string filters = "", string kwd = "")
        {
            RecipeSearchResult resultPage = new RecipeSearchResult();

            var searchQuery = _searchClient.Search<ArticlePage>();

            if (!string.IsNullOrWhiteSpace(kwd))
            {
                searchQuery = searchQuery.For(kwd)
                    .InFields(x => x.Heading, x => x.ShortDescription, x => x.Categories, x => x.SearchText());
            }

            if (!string.IsNullOrWhiteSpace(filters))
            {
                searchQuery = searchQuery.For(filters)
                    .InField(x => x.CategoryMenu);
            }

            var queryResults = searchQuery.GetContentResult();
            var totalResults = queryResults.TotalMatching;

            if (totalResults > 0)
            {
                resultPage.Items = queryResults.Select(x => new RecipeSearchItem
                {
                    Heading = x.Heading,
                    PageLink = x.ContentLink,
                    ImageLink = x.Image
                }).ToList();
            }
            else
            {

            }

            return resultPage;

        }

        #endregion




    }
}