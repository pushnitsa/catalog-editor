namespace CatalogEditor.DatabaseContext
{
    public interface IContextFactory
    {

        CatalogContext Create();
    }
}