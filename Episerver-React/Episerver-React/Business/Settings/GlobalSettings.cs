using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Settings
{
    public class GlobalSettings
    {
        /// <summary>
        /// Custom UI hints
        /// </summary>
        public static class CustomUiHints
        {
            public const string TemplateModel = "TemplateModel";
           
        }

        /// <summary>
        /// Custom tags that can be used as Display Option inside a Content Area
        /// </summary>
        public static class ContentAreaTags
        {   
            public const string TierOne = "tier-1";
            public const string TierTwo = "tier-2";
            public const string TierThree = "tier-3";
            public const string TopImage = "top-img";
            public const string BottomImage = "bottom-img";
            public static string RightImage = "right-img";
        }


        /// <summary>
        /// Custom rendering tags used by developers
        /// </summary>
        public static class RenderingTags
        {
            public const string RecipeIngredientTemplate = "RecipeTemplate";
            
        }

    }
}