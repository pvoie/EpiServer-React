using System;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Editor;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;

namespace Episerver_React.Business.Extensions
{
    public static class HtmlHelperExtensions
    {
        internal static Injected<IContentRepository> _contentRepository;
        internal static Injected<IContentVersionRepository> _versionRepository;
        internal static Injected<IPageRouteHelper> _pageRouteHelper;

        /// <summary>
        /// Builds the external (absolute) URL for a specific url
        /// </summary>
        /// <param name="html"></param>
        /// <param name="linkUrl"></param>
        /// <returns></returns>
        public static string ExternalUrl(this HtmlHelper html, string linkUrl)
        {
            if (string.IsNullOrWhiteSpace(linkUrl))
            {
                return string.Empty;
            }

            UrlBuilder pageURLBuilder = new UrlBuilder(linkUrl);
            if (pageURLBuilder.Uri.IsAbsoluteUri)
            {
                return linkUrl; //already external link
            }

            if (SiteDefinition.Current.SiteUrl != null)
            {
                UriBuilder uriBuilder = new UriBuilder(SiteDefinition.Current.SiteUrl);
                uriBuilder.Path = pageURLBuilder.ToString();

                return uriBuilder.Uri.AbsoluteUri;
            }

            return string.Empty;
        }

        public static String EnablePageEditing(this HtmlHelper html, object content)
        {
            var props = String.Empty;
            var item = content as IContent;
            if (item != null && PageEditing.PageIsInEditMode)
            {
                props = String.Format("{0}={1}", PageEditing.DataEPiBlockId, item.ContentLink);
            }
            return props;
        }

        public static void RenderContentData(this HtmlHelper html, ContentReference contentLink, bool isContentInContentArea, string templateTag, bool editMode)
        {
            if (editMode)
            {
                var versionRepo = _versionRepository.Service;
                var latest = versionRepo.List(contentLink).OrderByDescending(v => v.Saved).FirstOrDefault(v => v.IsMasterLanguageBranch);
                contentLink = latest != null ? latest.ContentLink : null;
            }

            IContent content;
            if (_contentRepository.Service.TryGet<IContent>(contentLink, out content))
            {
                html.RenderContentData(content, isContentInContentArea, templateTag);
            }
        }

        public static void RenderContentData(this HtmlHelper html, IContent contentData, bool isContentInContentArea, string templateTag, bool editMode)
        {
            RenderContentData(html, contentData.ContentLink, isContentInContentArea, templateTag, editMode);
        }

        public static void RenderContentData(this HtmlHelper html, ContentData contentData, bool isContentInContentArea, string templateTag, bool editMode)
        {
            var content = contentData as IContent;
            if (content != null)
            {
                RenderContentData(html, content.ContentLink, isContentInContentArea, templateTag, editMode);
            }
        }

        public static PageReference GetCurrentPage(this HtmlHelper html)
        {
            return _pageRouteHelper.Service.PageLink;
        }

        public static T GetCurrentPage<T>(this HtmlHelper html) where T : PageData
        {
            return _pageRouteHelper.Service.Page as T;
        }
    }
}