using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Episerver_React.Business.Factories
{
    public class LinkStyleSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
            {
                new SelectItem() { Text = "Default", Value = "" },
                new SelectItem() { Text = "Text Link", Value = "text" },
                new SelectItem() { Text = "Button Link", Value = "button" },
                new SelectItem() { Text = "hbh Button", Value = "hbhButton" }

            };
        }
    }
}