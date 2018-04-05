using Newtonsoft.Json;

namespace CatalogEditor.Deserializer
{
    public class EntityDeserializer : IEntityDeserializer
    {
        public TResult Deserialize<TResult>(string json)
        {
            return JsonConvert.DeserializeObject<TResult>(json);
        }
    }
}