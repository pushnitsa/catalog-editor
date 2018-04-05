using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogEditor.DatabaseContext;
using CatalogEditor.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogEditor.Fetcher
{
    public class CategoryFetcher : ICategoryFetcher
    {
        private readonly IContextFactory _contextFactory;
        
        public CategoryFetcher(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        public async Task<ICollection<DTO.Category>> GetCategoriesAsync()
        {
            ICollection<Category> categories;
            using (var context = _contextFactory.Create())
            {
                categories =  await context
                    .Categories
                    .ToListAsync();
            }

            var filteredCategories = FilterCategories(categories);
            
            var dtoCategories = ConvertToDTO(filteredCategories);

            return dtoCategories;
        }

        private ICollection<DTO.Category> ConvertToDTO(ICollection<Category> categories)
        {
            var dtoCategories = new List<DTO.Category>();
            
            foreach (var category in categories)
            {
                
                var dtoCategory = new DTO.Category
                {
                    Name = category.Name,
                    Id = category.Id
                };

                if (category.Childs.Count > 0)
                {
                    dtoCategory.Childs = ConvertToDTO(category.Childs).ToList();
                } 
                
                dtoCategories.Add(dtoCategory);
            }
            
            return dtoCategories;
        }

        private ICollection<Category> FilterCategories(ICollection<Category> categories)
        {
            return categories.Where(c => c.CategoryId == null).ToList();
        }
    }
}