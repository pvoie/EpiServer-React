using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "ResultItemBlock", 
        GUID = "ecde4e54-74b4-4a5f-8e73-e2694417d09b", 
        Description = "",
        AvailableInEditMode = false),]
    public class ResultItemBlock : BaseBlockData
    {

        
        public virtual string Name { get; set; }
        

    }
}