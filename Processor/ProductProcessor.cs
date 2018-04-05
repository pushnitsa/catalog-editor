using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogEditor.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CatalogEditor.Processor
{
    public class ProductProcessor
    {

        private readonly IContextFactory _contextFactory;

        public ProductProcessor(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IReadOnlyCollection<DTO.Product>> GetProductsAsync(int categoryId)
        {
            using (var context = _contextFactory.Create())
            {
                return await context
                    .Products
                    .Where(p => p.CategoryId == categoryId)
                    .OrderBy(p => p.Name)
                    .Select(p => new DTO.Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Image = p.Image,
                        Price = p.Price,
                        Quantity = p.Quantity
                    })
                    .ToListAsync();
            }
        }
    }
}