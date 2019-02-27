using EPiServer.Shell;
using Episerver_React.Models.Interfaces;
using Episerver_React.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Episerver_React.Business.UIDescriptors
{
    [UIDescriptorRegistration]
    public class ContainerPageUIDescriptor : UIDescriptor<IContainerPage>
    {
        public ContainerPageUIDescriptor()
            :base(ContentTypeCssClassNames.Folder)
        {

        }
    }
}