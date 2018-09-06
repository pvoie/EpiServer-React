using EPiServer.Core;
using EPiServer.Framework.Serialization;
using EPiServer.Framework.Serialization.Internal;
using EPiServer.ServiceLocation;

namespace Episerver_React.Models.Properties
{
    public class PropertyListBase<T> : PropertyList<T>
    {
        private readonly IObjectSerializer _objectSerializer;
        private Injected<ObjectSerializerFactory> _objectSerializerFactory;

        public PropertyListBase()
        {
            _objectSerializer = _objectSerializerFactory.Service.GetSerializer("application/json");
        }

        protected override T ParseItem(string value)
        {
            return _objectSerializer.Deserialize<T>(value);
        }

        public override PropertyData ParseToObject(string value)
        {
            ParseToSelf(value);
            return this;
        }
    }
}