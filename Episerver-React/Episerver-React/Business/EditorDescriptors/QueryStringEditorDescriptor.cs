using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using Episerver_React.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(IList<QueryStringUrl>))]
    public class QueryStringEditorDescriptor : CollectionEditorDescriptor<QueryStringUrl>
    {

    }
}