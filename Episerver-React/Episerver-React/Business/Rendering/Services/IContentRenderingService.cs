using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace Episerver_React.Business.Rendering.Services
{
    /// <summary>
    /// Service used to configure rendering for different IContentData items, that don't need a dedicated controller
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContentRenderingService<T> where T : IContentData
    {
        /// <summary>
        /// Gets available Template Models for this specific IContentData item
        /// </summary>
        /// <returns></returns>
        IEnumerable<TemplateModel> GetAvailableTemplates();
    }
}