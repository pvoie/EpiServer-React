using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Question Block", GUID = "3798b63e-abdb-4d91-bff8-b0a6db307d6e", Description = "Block for a question with answer")]
    public class QuestionBlock : BaseBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Question",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Question { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Answer",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString Answer { get; set; }

        

    }
}