using EPiServer.Web.Mvc;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;
using System;

namespace Episerver_React.Controllers
{
    public abstract class BasePageController<T> : PageController<T> where T : BasePageData
    {

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