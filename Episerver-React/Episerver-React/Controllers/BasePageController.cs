using EPiServer;
using EPiServer.Core;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;
using Episerver_React.Models.ViewModels;
using System;

namespace Episerver_React.Controllers
{
    public abstract class BasePageController<T> : PageController<T> where T : BasePageData
    {


        internal Injected<IContentRepository> _contentRepo;
        private readonly ILogger _logger = LogManager.GetLogger();


        /// <summary>
        /// Creates the simple page view mode
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        protected IPageViewModel<T> CreateModel(T page)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<T>;
        }

        /// <summary>
        /// Creates the page view model with additional settings
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        protected IPageViewModel<T> CreateModelWithSettings(T page)
        {
            var model = CreateModel(page);

            AddSettingsToModel(model);

            return model;
        }

        /// <summary>
        /// Creates the view model with additional settings
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        protected virtual TViewModel CreateModel<TViewModel>(BasePageData page) where TViewModel : IPageViewModel<BasePageData>
        {
            var type = typeof(TViewModel);
            var model = (TViewModel)Activator.CreateInstance(type, page);

            AddSettingsToModel(model);

            return model;
        }

        #region Private Helpers

        private void AddSettingsToModel<TViewModel>(TViewModel model) where TViewModel : IPageViewModel<BasePageData>
        {
            if (model == null || model.CurrentPage == null)
            {
                return;
            }

            var homePage = GetHomePage(model.CurrentPage);
            var siteSettings = GetSiteSettings(homePage);

            if (siteSettings == null)
            {
                return;
            }

            model.SiteSettings = siteSettings;

        }


        private HomePage GetHomePage(BasePageData page)
        {
            if (page == null || _contentRepo.Service == null)
            {
                return null;
            }


            //check if this is the home poage
            var home = page as HomePage;
            if (home != null)
            {
                return home;
            }

            //get the home page
            _contentRepo.Service.TryGet(ContentReference.StartPage, out home);
            return home;


        }


        private SiteSettingsBlock GetSiteSettings(HomePage page)
        {
            if (page == null || _contentRepo.Service == null)
            {
                return null;
            }

            if (ContentReference.IsNullOrEmpty(page.SiteSettings))
            {
                return null;
            }

            SiteSettingsBlock block = null;
            _contentRepo.Service.TryGet(page.SiteSettings, out block);
            return block;

        }


        #endregion Private Helpers
    }
}