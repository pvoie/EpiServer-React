using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Episerver_React.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Episerver_React.Models.Pages
{
    [ContentType(DisplayName = "Folder Page", GUID = "502acfa2-bbda-48a7-9003-036faab0dbec", Description = "A placeholder to help organise the EPiServer page tree")]
    public class FolderPage : BasePageData, IContainerPage
    {

        

    }
}