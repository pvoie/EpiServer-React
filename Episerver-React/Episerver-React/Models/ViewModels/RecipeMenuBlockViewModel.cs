using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Episerver_React.Models.Blocks;
using Episerver_React.Models.Pages;
using System.Collections.Generic;
using System.Linq;

namespace Episerver_React.Models.ViewModels
{
    public class RecipeMenuBlockViewModel : BlockViewModel<RecipeMenuBlock>
    {
        internal protected Injected<IContentRepository> _contentRepo;

        public RecipeMenuBlockViewModel(RecipeMenuBlock recipeBlock) : base(recipeBlock)
        {

            MenuCategories = new List<string>();
            FirstColumn = new List<string>();
            SecondColumn = new List<string>();

        }

        public IEnumerable<string> MenuCategories { get; set; }

        public List<string> FirstColumn { get; set; }

        public List<string> SecondColumn { get; set; }

        public ContentReference MainLandingPageLink { get; set; }

        public ContentReference RecipeSearchPage { get; set; }


        public void SplitCategoriesInColumns(int minColumnCount = 3)
        {
            if (MenuCategories == null || !MenuCategories.Any())
            {
                return;
            }

            var totalItems = MenuCategories.Count();

            if (totalItems >= minColumnCount)
            {
                FirstColumn.AddRange(MenuCategories);
                return;
            }

            var fisrtColSize = totalItems / 2 + 1;

            FirstColumn.AddRange(MenuCategories.Take(fisrtColSize));
            SecondColumn.AddRange(MenuCategories.Skip(fisrtColSize));
        }


        public void InitializePageLinks()
        {
            HomePage home = null;
            _contentRepo.Service.TryGet(ContentReference.StartPage, out home);

            if ( home == null || ContentReference.IsNullOrEmpty(home.SiteSettings))
            {
                return;
            }

            SiteSettingsBlock settings = null;
            _contentRepo.Service.TryGet(home.SiteSettings, out settings);

            if (settings == null)
            {
                return;
            }

            MainLandingPageLink = settings.HomeLandingPage;
            RecipeSearchPage = settings.RecipeSearchPage;

        }
    }
}