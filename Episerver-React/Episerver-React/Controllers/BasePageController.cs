using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Caching;
using EPiServer;
using EPiServer.Core;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;
using Episerver_React.Models.ViewModels;

namespace Episerver_React.Controllers
{
    public abstract class BasePageController<T> : PageController<T> where T : BasePageData
    {
        internal Injected<IContentRepository> _contentRepo;



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
            
            
            

        }


        private HomePage GetHomePage(BasePageData page)
        {
            if (page == null || _contentRepo.Service == null)
            {
                return null;
            }

            //checks if this is the home page
            var homePage = page as HomePage;
            if (homePage != null)
            {
                return homePage;
            }

            _contentRepo.Service.TryGet(ContentReference.StartPage, out homePage);
            return homePage;
        }


        private SiteSettingsBlock GetSiteSettings(HomePage page)
        {
            if (page == null || _contentRepo.Service == null)
            {
                return null;
            }
            if (ContentReference.IsNullOrEmpty(page.SiteSettings) == null)
            {
                return null;
            }

            SiteSettingsBlock settings = null;
            _contentRepo.Service.TryGet(page.SiteSettings, out settings);
            return settings;
        }

        #endregion
    }
}