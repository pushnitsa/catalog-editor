using System.Threading.Tasks;

namespace CatalogEditor.Initializer
{
    public interface IDatabaseInitializer
    {
        Task Seed();
    }
}