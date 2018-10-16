using EPiServer;
using EPiServer.Core;
using EPiServer.Shell.Services.Rest;
using EPiServer.Web;
using Episerver_React.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Episerver_React.Business.RestServices
{
    /// <summary>
    /// Gets display options for special renderings
    /// </summary>
    [RestStore("supporteddisplayoptions")]
    public class SupportedDisplayOptionsStore : RestControllerBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly DisplayOptions _displayOptions;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contentLoader"></param>
        /// <param name="displayOptions"></param>
        public SupportedDisplayOptionsStore(IContentLoader contentLoader, DisplayOptions displayOptions)
        {
            if (contentLoader == null) throw new ArgumentNullException(nameof(contentLoader));
            if (displayOptions == null) throw new ArgumentNullException(nameof(displayOptions));

            _contentLoader = contentLoader;
            _displayOptions = displayOptions;
        }

        /// <summary>
        /// Get options for content
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public RestResult Get(ContentReference id)
        {
            IContent content;

            if (!_contentLoader.TryGet(id, out content))
            {
                return Default(id);
            }

            var specialRenderingContent = content as ISpecialRenderingContent;

            if (specialRenderingContent != null)
            {
                var supportedDisplayOptions =
                    _displayOptions
                        .Where(x => specialRenderingContent.SupportedDisplayOptions.Contains(x.Tag, StringComparer.CurrentCultureIgnoreCase));

                //return Rest(supportedDisplayOptions.Select(x => x.Id));
                return Rest(new SupportedResultModel(id, supportedDisplayOptions));
            }

            // Default to all display options.
            return Default(id);
        }

        private RestResult Default(ContentReference id) => Rest(new SupportedResultModel());

        internal class SupportedResultModel
        {
            public string contentLink { get; }

            public IEnumerable<string> options { get; }

            public SupportedResultModel(ContentReference _contentLink = null, IEnumerable<DisplayOption> _options = null)
            {
                contentLink = _contentLink?.ID.ToString() ?? "-1";
                options = _options?.Select(x => x.Id).OrderBy(x => x);

            }
        }
    }
}
