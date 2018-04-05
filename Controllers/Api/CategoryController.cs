using System.Threading.Tasks;
using CatalogEditor.Fetcher;
using CatalogEditor.Serializer;
using Microsoft.AspNetCore.Mvc;

namespace CatalogEditor.Controllers.Api
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly IEntitySerializer _serializer;
        private readonly ICategoryFetcher _categoryFetcher;
        
        public CategoryController(IEntitySerializer serializer, ICategoryFetcher categoryFetcher)
        {
            _serializer = serializer;
            _categoryFetcher = categoryFetcher;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryFetcher.GetCategoriesAsync();
            
            return new ObjectResult(_serializer.Serialize(categories));
        }
    }
}