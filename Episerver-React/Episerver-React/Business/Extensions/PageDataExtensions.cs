using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Episerver_React.Models.Interfaces;

namespace Episerver_React.Business.Extensions
{
    public static class PageDataExtensions
    {
        internal static Injected<IContentRepository> _contentRepository;
        internal static Injected<UrlResolver> _urlResolver;
        internal static Injected<CategoryRepository> _categoriesRepository;

        public static bool IsOrDescendsFrom(this PageData pageData, ContentReference target)
        {
            if (target == null) return false;
            else if (pageData.ContentLink.ID == target.ID) return true;
            return DescendsFrom(pageData, target);
        }

        public static bool IsOrDescendsFrom(this PageData pageData, Url url)
        {
            var content = _urlResolver.Service.Route(new UrlBuilder(url));
            return IsOrDescendsFrom(pageData, content != null ? content.ContentLink : null);
        }

        public static bool DescendsFrom(this PageData pageData, ContentReference target)
        {
            if (target == null) return false;
            var ancestors = _contentRepository.Service.GetAncestors(pageData.ContentLink);
            return ancestors.Contains(_contentRepository.Service.Get<IContent>(target));
        }

        public static bool DecendsFromFolder(this PageData pageData, Url url)
        {
            var content = _urlResolver.Service.Route(new UrlBuilder(url));
            if (content == null || ContentReference.IsNullOrEmpty(content.ContentLink))
            {
                return false;
            }

            return DecendsFromFolder(pageData, content.ContentLink);
        }

        public static bool DecendsFromFolder(this PageData pageData, ContentReference target)
        {
            var targetAncestors = _contentRepository.Service.GetAncestors(target);
            var pageAncestors = _contentRepository.Service.GetAncestors(pageData.ContentLink);

            if (targetAncestors == null || !targetAncestors.Any() || pageAncestors == null || !pageAncestors.Any())
            {
                return false;
            }

            var targetFolderAncestors = targetAncestors.Where(x => x is IContainerPage);
            if (targetFolderAncestors == null || !targetFolderAncestors.Any())
            {
                return false;
            }

            var found = false;
            foreach (var currentFolder in targetFolderAncestors)
            {
                if (pageAncestors.FirstOrDefault(x => x.ContentGuid.Equals(currentFolder.ContentGuid)) != null)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        /// <summary>
        /// Gets the text for categories.
        /// </summary>
        /// <param name="pageData">The page data.</param>
        /// <returns>List of text for categories.</returns>
        public static IEnumerable<string> GetTextForCategories(this PageData pageData)
        {
            var textForCategories = new List<string>();

            if (pageData == null || pageData.Category == null)
            {
                return null;
            }

            if (_categoriesRepository.Service == null)
            {
                return null;
            }

            foreach (var categoryId in pageData.Category)
            {
                Category category = _categoriesRepository.Service.Get(categoryId);

                if (category != null)
                {
                    textForCategories.Add(category.LocalizedDescription);
                }
            }

            return textForCategories;
        }
    }
}