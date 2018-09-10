using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;



namespace Episerver_React.Business.Initialization
{  
    [ModuleDependency(typeof(TinyMceInitialization))]    
    public class CustomizedTinyMceInitialization : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
          
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                config.Default()
                    .Plugins("epi-link epi-image-editor epi-dnd-processor epi-personalized-content code table importcss fullscreen lists")
                    .Toolbar(
                        "epi-link | epi-image-editor | epi-personalized-content | cut copy paste | fullscreen",
                        "styleselect | bold italic strikethrough forecolor backcolor | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat",
                        "table | code");
            });
        }
    }
}