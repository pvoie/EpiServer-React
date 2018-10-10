using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Episerver_React.Business.Rendering;

namespace Episerver_React.Business.Extensions
{
    public static class ContentAreaExtensions
    {
        internal static Injected<CustomContentAreaRenderer> _customContentAreaRenderer;
        internal static Injected<IContentRepository> _contentRepository;
        internal static Injected<IContentVersionRepository> _versionRepository;

        public static void RenderCustomContentArea(this HtmlHelper htmlHelper, ContentArea contentArea)
        {
            _customContentAreaRenderer.Service.Render(htmlHelper, contentArea);
        }

        /// <summary>
        /// Returns bool to indicate if content area has published items available for the current visitor
        /// </summary>
        /// <param name="contentArea"></param>
        /// <returns></returns>
        public static bool Any(this ContentArea contentArea)
        {
            return (contentArea != null && contentArea.FilteredItems != null && contentArea.FilteredItems.Count() > 0);
        }

        /// <summary>
        /// Returns a list of typed pages from the Content Area
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contentArea"></param>
        /// <returns></returns>
        public static IEnumerable<T> FilteredItemsOfType<T>(this ContentArea contentArea, bool editMode = false) where T : IContentData
        {
            var list = new List<T>();
            if (contentArea.Any())
            {
                foreach (var item in contentArea.FilteredItems)
                {
                    var content = GetItem<T>(item.ContentLink, editMode);
                    if (content != null)
                    {
                        list.Add(content);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Returns a list of typed pages from the Content Area where a display option has been selected
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contentArea"></param>
        /// <returns></returns>
        public static IEnumerable<T> FilteredItemsOfTypeWithDisplayOption<T>(this ContentArea contentArea, bool editMode = false) where T : IContentData
        {
            var list = new List<T>();
            if (contentArea.Any())
            {
                foreach (var item in contentArea.FilteredItems)
                {
                    if (item.LoadDisplayOption() != null)
                    {
                        var content = GetItem<T>(item.ContentLink, editMode);
                        if (content != null)
                        {
                            list.Add(content);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Returns a list of typed pages from the Content Area where a specific display option has been selected
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contentArea"></param>
        /// <param name="displayOptions"></param>
        /// <param name="editMode"></param>
        /// <returns></returns>
        public static IEnumerable<T> FilteredItemsOfTypeWithDisplayOption<T>(this ContentArea contentArea, string[] displayOptions, bool editMode = false) where T : IContentData
        {
            var list = new List<T>();
            if (contentArea.Any())
            {
                foreach (var item in contentArea.FilteredItems)
                {
                    if (item.LoadDisplayOption() != null && displayOptions.Contains(item.LoadDisplayOption().Tag))
                    {
                        var content = GetItem<T>(item.ContentLink, editMode);
                        if (content != null)
                        {
                            list.Add(content);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Returns the data for the content area item, using the latest version if in edit mode.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="editMode"></param>
        /// <returns></returns>
        public static T GetItem<T>(this ContentAreaItem item, bool editMode) where T : IContentData
        {
            return GetItem<T>(item.ContentLink, editMode);
        }

        /// <summary>
        /// Get the content data object using the latest version if in edit mode.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contentLink"></param>
        /// <param name="editMode"></param>
        /// <returns></returns>
        public static T GetItem<T>(ContentReference contentLink, bool editMode) where T : IContentData
        {
            if (editMode)
            {
                var versionRepo = _versionRepository.Service;
                var latest = versionRepo.List(contentLink).OrderByDescending(v => v.Saved).FirstOrDefault(v => v.IsMasterLanguageBranch);
                contentLink = latest.ContentLink;
            }

            T content;
            _contentRepository.Service.TryGet<T>(contentLink, LanguageSelector.AutoDetect(false), out content);

            return content;
        }

        /// <summary>
        /// Gets the total number of "pages" from a content area based on a provided page size (use this if you want to build a pagination system based on content area items)
        /// </summary>
        /// <param name="contentArea"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int GetTotalNumberOfPages(this ContentArea contentArea, int pageSize)
        {
            int totalPages = 0;
            if (contentArea.Any() && pageSize > 0)
            {
                totalPages = contentArea.Count / pageSize;
                if (contentArea.Count % pageSize != 0)
                {
                    totalPages++;
                }
            }
            return totalPages;
        }

        /// <summary>
        /// Helper method used for pagination - tries to get the items for a specific page number and size
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contentArea"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns>Empty list if nothing is found</returns>
        public static IEnumerable<T> GetPageItems<T>(this ContentArea contentArea, int currentPage, int pageSize) where T : IContentData
        {
            var list = new List<T>();
            if (currentPage > 0 && pageSize > 0 &&
                contentArea.Any() && contentArea.GetTotalNumberOfPages(pageSize) >= currentPage)
            {
                list = contentArea.FilteredItemsOfType<T>().Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }
            return list;
        }
    }
}