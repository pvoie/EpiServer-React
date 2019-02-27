using EPiServer.DataAbstraction;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Pages;
using Episerver_React.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Episerver_React.Controllers
{
    public class RecipeMenuBlockController : BlockController<RecipeMenuBlock>
    {
        internal protected Injected<CategoryRepository> _categoryRepo;

        public override ActionResult Index(RecipeMenuBlock currentBlock)
        {
            var model = new RecipeMenuBlockViewModel(currentBlock);

            var searchQuery = SearchClient.Instance.Search<ArticlePage>()
                .FilterForVisitor()
                .TermsFacetFor(x => x.CategoryMenu, r => r.Size = 1000)
                .Take(0);

            var results = searchQuery.GetContentResult();

            var categoryFilters = results.TermsFacetFor(x => x.CategoryMenu).Terms;

            model.MenuCategories = categoryFilters.Select(x => x.Term);
            model.SplitCategoriesInColumns();
            model.InitializePageLinks();
            
            return PartialView(string.Format("~/Views/Blocks/{0}.cshtml",currentBlock.ViewName),model);
        }
    }
}