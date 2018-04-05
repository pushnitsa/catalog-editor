using Newtonsoft.Json;

namespace CatalogEditor.Serializer
{
    public class EntitySerializer : IEntitySerializer
    {
        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}