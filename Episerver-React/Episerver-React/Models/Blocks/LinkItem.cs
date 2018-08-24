using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using Episerver_React.Business.Factories;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Link Item",
        GUID = "b9742ea3-de5c-4d9e-a26f-837237e90e07",
        Description = "Simple text link item")]
    public class LinkItem : BaseBlockData
    {
        [Display(
           Name = "URL",
           Order = 10,
           GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        public virtual Url Link { get; set; }

        [Display(
            Name = "Text",
            Order = 20,
            GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        public virtual string Text { get; set; }

        [Display(
            Name = "Title",
            Order = 30,
            GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(
            Name = "Target",
            Order = 40,
            GroupName = SystemTabNames.Content)]
        [SelectOne(SelectionFactoryType = typeof(LinkTargetSelectionFactory))]
        [CultureSpecific]
        public virtual string Target { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(
           Name = "Link Style",
           Order = 60,
           GroupName = SystemTabNames.Content)]
        [SelectOne(SelectionFactoryType = typeof(LinkStyleSelectionFactory))]
        [CultureSpecific]
        public virtual string LinkStyle { get; set; }
    }
}