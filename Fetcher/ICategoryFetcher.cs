using System.Collections.Generic;
using System.Threading.Tasks;
using DateTimeOffset = CatalogEditor.DTO;

namespace CatalogEditor.Fetcher
{
    public interface ICategoryFetcher
    {
        Task<ICollection<DTO.Category>> GetCategoriesAsync();
    }
}