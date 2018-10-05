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
        private const int DefaultPageSize = 3;

        public ActionResult Index(ResultsPage currentPage, string filters = "", string q = "")
        {
            var model = CreateRecipeSearchModelWithSettings(currentPage) as RecipeSearchResultViewModel<ResultsPage>;

            var itemsPerPage = model.CurrentPage.PageSize;
            model.ResultPage = RecipeSearch(filters, q, itemsPerPage);

            return View(string.Format("~/Views/Pages/{0}/Index.cshtml", currentPage.ViewName), model);
        }


        public ActionResult AjaxSearch(ResultsPage currentPage, string filters = "", string q ="", int pageNumber = 1)
        {
            var model = CreateRecipeSearchModelWithSettings(currentPage) as RecipeSearchResultViewModel<ResultsPage>;

            var itemsPerPage = model.CurrentPage.PageSize;
            model.ResultPage = RecipeSearch(filters, q, itemsPerPage, pageNumber);

            return PartialView("~/Views/Pages/ResultsPage/_recipeSearchResults.cshtml", model);
        }



        #region Search

        private RecipeSearchResult RecipeSearch(string filters = "", string kwd = "", int itemsPerPage = 3, int currentPage = 1)
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

            var skipNumber = (currentPage - 1) * itemsPerPage;
            searchQuery = searchQuery.Skip(skipNumber).Take(itemsPerPage);
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

                resultPage.PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = currentPage,
                    ItemsPerPage = itemsPerPage,
                    TotalItems = totalResults
                };
            }
            else
            {

            }

            return resultPage;

        }

        #endregion




    }
}