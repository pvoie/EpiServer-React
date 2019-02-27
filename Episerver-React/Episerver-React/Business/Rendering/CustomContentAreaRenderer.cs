using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using EPiServer;
using EPiServer.Core;
using EPiServer.Editor;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using Episerver_React.Models.ViewModels;

namespace Episerver_React.Business.Rendering
{
    [ServiceConfiguration(typeof(CustomContentAreaRenderer), Lifecycle = ServiceInstanceScope.Transient)]
    public class CustomContentAreaRenderer : ContentAreaRenderer
    {
        private readonly ILogger _logger = LogManager.GetLogger();
        private readonly IContentAreaItemAttributeAssembler _attributeAssembler;
        private readonly IContentRenderer _contentRenderer;
        private readonly IContentRepository _contentRepository;
        private readonly TemplateResolver _templateResolver;

        public CustomContentAreaRenderer(IContentRenderer contentRenderer, TemplateResolver templateResolver,
            IContentAreaItemAttributeAssembler attributeAssembler, IContentRepository contentRepository,
            IContentAreaLoader contentAreaLoader)
            : base(contentRenderer, templateResolver, attributeAssembler, contentRepository, contentAreaLoader)
        {
            _contentRenderer = contentRenderer;
            _templateResolver = templateResolver;
            _attributeAssembler = attributeAssembler;
            _contentRepository = contentRepository;
        }

        protected override void RenderContentAreaItem(HtmlHelper htmlHelper, ContentAreaItem contentAreaItem, string templateTag, string htmlTag, string cssClass)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary["childrencustomtagname"] = htmlTag;
            dictionary["childrencssclass"] = cssClass;
            dictionary["tag"] = templateTag;

            dictionary = contentAreaItem.RenderSettings.Concat(
                (
                from r in dictionary
                where !contentAreaItem.RenderSettings.ContainsKey(r.Key)
                select r
                )
            ).ToDictionary(r => r.Key, r => r.Value);

            htmlHelper.ViewBag.RenderSettings = dictionary;
            var content = contentAreaItem.GetContent();

            if (content != null)
            {
                try
                {
                    using (new ContentAreaContext(htmlHelper.ViewContext.RequestContext, content.ContentLink))
                    {
                        var templateModel = ResolveTemplate(htmlHelper, content, templateTag);
                        if ((templateModel != null) || IsInEditMode(htmlHelper))
                        {
                            if (IsInEditMode(htmlHelper))
                            {
                                var tagBuilder = new TagBuilder(htmlTag);
                                AddNonEmptyCssClass(tagBuilder, cssClass);
                                tagBuilder.MergeAttributes<string, string>(
                                    _attributeAssembler.GetAttributes(
                                        contentAreaItem, IsInEditMode(htmlHelper), (bool)(templateModel != null)));
                                BeforeRenderContentAreaItemStartTag(tagBuilder, contentAreaItem);
                                htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
                                htmlHelper.RenderContentData(content, true, templateModel, _contentRenderer);
                                htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.EndTag));
                            }
                            else
                            {
                                htmlHelper.RenderContentData(content, true, templateModel, _contentRenderer);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.Error("[CustomContentAreaRenderer.RenderContentAreaItem] exception", e);

                    if (PageEditing.PageIsInEditMode)
                    {
                        var errorModel = new ContentRenderingErrorModel(content, e);
                        htmlHelper.RenderPartial("TemplateError", errorModel);
                    }
                }
            }
        }

        private void RenderEditorView()
        {

        }

        protected override bool ShouldRenderWrappingElement(HtmlHelper htmlHelper)
        {
            return false;
        }
    }
}