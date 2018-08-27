using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.DataAbstraction;
using EPiServer.Framework.Web;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.Web.Routing;
using Episerver_React.Business.Settings;

namespace Episerver_React.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = GlobalSettings.CustomUiHints.TemplateModel)]
    public class TemplateModelEditorDescriptor : EditorDescriptor
    {
        private readonly ITemplateRepository _templateModelRepository;
        private readonly ILogger _logger = LogManager.GetLogger();

        public TemplateModelEditorDescriptor()
            : this(ServiceLocator.Current.GetInstance<ITemplateRepository>())
        {
        }

        public TemplateModelEditorDescriptor(ITemplateRepository templateModelRepository)
        {
            if (templateModelRepository == null)
                throw new ArgumentNullException("templateModelRepository");

            _templateModelRepository = templateModelRepository;

            ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";
        }

        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);

            metadata.CustomEditorSettings["uiType"] = metadata.ClientEditingClass;
            metadata.CustomEditorSettings["uiWrapperType"] = UiWrapperType.Floating;
            //Type contentType = metadata.ContainerType;

            /* 'metadata.ContainerType no longer returns the correct Type value as of 10.10.1
             * To work around this, we are now doing the below ugly casting to get the Type ID
             * of the content type being created, so we can then get the actual type from the database
             * in order to get the appropriate templates listed in the editor.
             * Should this bug ever get fixed (not confirmed as bug yet, as of Aug 2, 2017)
             * we can revert to simply using the ContainerType property.
             */

            int typeId = 0;

            try
            {
                typeId = ((EPiServer.Core.IContent)((EPiServer.Cms.Shell.UI.ObjectEditing.ContentDataMetadata)metadata).OwnerContent).ContentTypeID;
            }
            catch (Exception ex)
            {
                _logger.Error("Exception on ModifyMetadata", ex);
            }

            if (typeId > 0)
            {
                var contentType = ServiceLocator.Current.GetInstance<IContentTypeRepository>().Load(typeId).ModelType;
                TemplateTypeCategories[] validTemplateTypeCategories;

                if (typeof(IRoutable).IsAssignableFrom(contentType))
                {
                    validTemplateTypeCategories = new[] {
                        TemplateTypeCategories.MvcController,
                        TemplateTypeCategories.WebFormsPage,
                        TemplateTypeCategories.WebForms,
                        TemplateTypeCategories.MvcView,
                        TemplateTypeCategories.Page
                    };
                }
                else
                {
                    validTemplateTypeCategories = new[] {
                        TemplateTypeCategories.MvcPartialController,
                        TemplateTypeCategories.MvcPartialView,
                        TemplateTypeCategories.WebFormsPartial,
                        TemplateTypeCategories.ServerControl,
                        TemplateTypeCategories.UserControl
                    };
                }

                var templateModels = _templateModelRepository
                    .List(contentType)
                    .Where(x => Array.IndexOf(validTemplateTypeCategories, x.TemplateTypeCategory) > -1);

                var secondaryModels = templateModels.Where(x => x.TemplateType.Name != "DefaultPageController").Select(x => new SelectItem
                {
                    Text = x.Name ?? x.TemplateType.Name,
                    Value = x.TemplateType.FullName // Value stored in the database
                }).ToList();

                secondaryModels.Insert(0, new SelectItem { Text = "", Value = "" });

                metadata.EditorConfiguration["selections"] = secondaryModels;
            }
        }
    }
}