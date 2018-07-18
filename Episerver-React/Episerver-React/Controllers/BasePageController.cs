using EPiServer;
using EPiServer.Web.Mvc;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;
using Episerver_React.Models.ViewModels;
using System;

namespace Episerver_React.Controllers
{
    public abstract class BasePageController<T> : PageController<T> where T : BasePageData
    {
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
        }
        #endregion
    }
}