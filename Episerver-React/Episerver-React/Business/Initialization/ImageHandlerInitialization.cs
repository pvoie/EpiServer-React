using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Episerver_React.Models.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ImageHandlerInitialization : IInitializableModule
    {
        private Injected<IContentEvents> _contentEvents;

        public void Initialize(InitializationEngine context)
        {
            _contentEvents.Service.CreatedContent += ImageProcessor;
        }

        public void Uninitialize(InitializationEngine context)
        {

        }

        public void ImageProcessor(object sender, ContentEventArgs e)
        {
            var content = e.Content;

            //verify if the content is a site image.
            if (!(content is SiteImage))
            {
                return;
            }
            var image = content as SiteImage;
            
            //Create a clone with write access
            var imageClone = image.CreateWritableClone() as SiteImage;
            imageClone.Extension = image.BinaryData.ToString().Split('.').Last();
            imageClone.Mime = image.MimeType;

            using (var imageData = Image.FromStream(image.BinaryData.OpenRead()))
            {
                imageClone.Width = imageData.Width;
                imageClone.Height = imageData.Height;
            }

            DataFactory.Instance.Save(imageClone, SaveAction.Publish);
        }
    }
}