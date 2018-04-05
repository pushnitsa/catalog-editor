using System.Threading.Tasks;
using CatalogEditor.DatabaseContext;

namespace CatalogEditor.Initializer
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IContextFactory _contextFactory;
        
        public DatabaseInitializer(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        public async Task Seed()
        {
            throw new System.NotImplementedException();
        }
    }
}