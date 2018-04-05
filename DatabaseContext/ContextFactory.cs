using Microsoft.EntityFrameworkCore;

namespace CatalogEditor.DatabaseContext
{
    public class ContextFactory : IContextFactory
    {
        private readonly DbContextOptions _options;
        
        public ContextFactory(DbContextOptions options)
        {
            _options = options;
        }
        public CatalogContext Create()
        {   
            return new CatalogContext(_options);
        }
    }
}