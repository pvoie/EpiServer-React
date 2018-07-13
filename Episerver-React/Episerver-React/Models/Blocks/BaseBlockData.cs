using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Episerver_React.Models.Blocks
{
    [ContentType(DisplayName = "Base Block Data",
        GUID = "8632d889-e553-43e0-8f24-27d17c33b2e7",
        Description = "Base abstract class used for blocks, if you don't need to support author selected templates",
        AvailableInEditMode = false)]
    public abstract class BaseBlockData : BlockData
    {
        #region Helpers

        public virtual string ViewName
        {
            get { return this.GetOriginalType().Name; }
        }

        #endregion
    }
}