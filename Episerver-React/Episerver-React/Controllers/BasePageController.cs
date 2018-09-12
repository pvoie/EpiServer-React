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
            model.HeaderHtml = GetHtmlToInjectForBlock(siteSettings.HeaderBlock, true);
            model.FooterHtml = GetHtmlToInjectForBlock(siteSettings.FooterBlock);



        }

        private string GetHtmlToInjectForBlock(HtmlInjectedBlock block, bool removeViewportMeta = false)
        {
            if (block == null || string.IsNullOrWhiteSpace(block.SourceUrl))
            {
                return string.Empty;
            }

            //try to get the result from cache
            Cache cache = HttpRuntime.Cache;
            var cacheKey = string.Format("HIB:{0}",
                block.SourceUrl);

            var result = string.Empty;

            if (block.CacheDurationHours > 0)
            {
                var cachedHtml = cache.Get(cacheKey);
                result = cachedHtml != null ? cachedHtml.ToString() : string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(result))
            {
                return result;
            }

            result = DownloadExternalHtml(block.SourceUrl, block.RequestTimeoutSeconds);

            //check if we want to add the result to cache
            if (!string.IsNullOrWhiteSpace(result) && block.CacheDurationHours > 0)
            {
                cache.Add(cacheKey,
                    result,
                    null,
                    DateTime.Now.AddHours(block.CacheDurationHours),
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Normal,
                    null);
            }

            return result;
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


        private string DownloadExternalHtml(string sourceUrl, int timeoutSeconds)
        {
            if (string.IsNullOrWhiteSpace(sourceUrl))
            {
                return string.Empty;
            }

            string result = string.Empty;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(sourceUrl);
                request.Method = "GET";
                request.Accept = @"text/html, application/xhtml+xml, */*";
                request.Timeout = (timeoutSeconds > 0 ? timeoutSeconds : 15) * 1000;//fallback to 15 seconds timeout

                using (var response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    int iTotalBuff = 0;
                    byte[] buffer = new byte[128];

                    iTotalBuff = stream.Read(buffer, 0, 128);
                    StringBuilder strRes = new StringBuilder();

                    while (iTotalBuff != 0)
                    {
                        strRes.Append(Encoding.ASCII.GetString(buffer, 0, iTotalBuff));
                        iTotalBuff = stream.Read(buffer, 0, 128);
                    }
                    result = strRes.ToString();
                    strRes.Clear();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("[BasePageController.GetHtmlToInjectForBlock] Error getting external HTML", ex);
            }

            return result;
        }
        #endregion
    }
}