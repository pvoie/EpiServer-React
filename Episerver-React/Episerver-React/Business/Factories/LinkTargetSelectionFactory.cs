using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Episerver_React.Business.Factories
{
    public class LinkTargetSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
            {
                new SelectItem() { Text = "Open in same window", Value = "" },
                new SelectItem() { Text = "Open in new window", Value = "_blank" },
            };
        }
    }
}