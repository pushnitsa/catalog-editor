namespace CatalogEditor.Serializer
{
    public interface IEntitySerializer
    {
        string Serialize(object value);
    }
}