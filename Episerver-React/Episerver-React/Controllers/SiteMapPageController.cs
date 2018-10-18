using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web;
using Episerver_React.Models.Pages;
using Episerver_React.Models.SiteMapModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Episerver_React.Controllers
{
    public class SiteMapPageController : BasePageController<SiteMapPage>
    {
        private readonly IContentLoader _contentLoader;

        public SiteMapPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public ActionResult Index(SiteMapPage currentPage)
        {
            var model = CreateSiteMapModelWithSettings(currentPage) as SiteMapViewModel<SiteMapPage>;
            model.SiteMap.MenuItems = GetMenuItemsRecursive(SiteDefinition.Current.StartPage);

            return View(string.Format("~/Views/Pages/{0}/Index.cshtml", currentPage.ViewName), model);
        }

        private IEnumerable<MenuItem> GetMenuItemsRecursive(ContentReference contentLink)
        {
            var publishedFilter = new FilterPublished();
            var accessFilter = new FilterAccess();

            var menuItems = _contentLoader
        .GetChildren<BasePageData>(contentLink)
        .Where(p => p.VisibleInSiteMap && !publishedFilter.ShouldFilter(p) && !accessFilter.ShouldFilter(p))
        .Select(p => new MenuItem
        {
            Name = p.Name,
            ContentLink = p.ContentLink,
            Children = GetMenuItemsRecursive(p.ContentLink)
        });

            return menuItems;
        }
    }
}