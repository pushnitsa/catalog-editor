using System.Runtime.InteropServices;
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
                var category1 = new Category { Name = "Одежда, обувь, аксессуары" };
                var category2 = new Category { Name = "Женская одежда"};
                var category3 = new Category { Name = "Верхняя" };
                var category4 = new Category { Name = "Плащи" };
                
                category1.Childs.Add(category2);
                category2.Childs.Add(category3);
                category3.Childs.Add(category4);

                await context.Categories.AddRangeAsync(category1, category2, category3, category4);
                
                var product1 = new Product
                {
                    Category = category1,
                    Name = "TestProduct",
                    Price = 10M,
                    Quantity = 100,
                    Image = "img.png"
                };
                
                var product2 = new Product
                {
                    Category = category1,
                    Name = "TestProduct2",
                    Price = 20M,
                    Quantity = 200,
                    Image = "img.png"
                };

                await context.Products.AddRangeAsync(product1, product2);

                await context.SaveChangesAsync();
            }
        }
    }
}