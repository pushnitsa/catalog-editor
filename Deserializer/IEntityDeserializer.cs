namespace CatalogEditor.Deserializer
{
    public interface IEntityDeserializer
    {
        TResult Deserialize<TResult>(string json);
    }
}