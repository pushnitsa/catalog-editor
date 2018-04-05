using System.Threading.Tasks;
using CatalogEditor.DatabaseContext;
using CatalogEditor.Models;

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
            using (var context = _contextFactory.Create())
            {
                var category = new Category { Name = "TestCategory" };

                await context.Categories.AddAsync(category);
                
                var product = new Product
                {
                    Category = category,
                    Name = "TestProduct",
                    Price = 10M,
                    Quantity = 100
                };

                await context.Products.AddAsync(product);

                await context.SaveChangesAsync();
            }
        }
    }
}