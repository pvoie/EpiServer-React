using EPiServer.Web.Mvc;
using Episerver_React.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Episerver_React.Controllers
{
    public class BlogContentBlockController : BlockController<BlogContentBlock>
    {
        public override ActionResult Index(BlogContentBlock currentBlock)
        {
            if (currentBlock.Images != null)
            {
                return PartialView(string.Format("~/Views/Blocks/{0}/{1}", 
                    currentBlock.ViewName, 
                    string.Format("BlogContentImg{0}.cshtml", currentBlock.Images.Count)),currentBlock);
            }


            return PartialView();
        }



    }
}