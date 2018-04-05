using System.Threading.Tasks;
using CatalogEditor.Fetcher;
using CatalogEditor.Processor;
using CatalogEditor.Serializer;
using Microsoft.AspNetCore.Mvc;

namespace CatalogEditor.Controllers.Api
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly IEntitySerializer _serializer;
        private readonly ICategoryFetcher _categoryFetcher;
        private readonly ProductProcessor _productProcessor;
        
        public CategoryController(
            IEntitySerializer serializer, 
            ICategoryFetcher categoryFetcher,
            ProductProcessor productProcessor
        )
        {
            _serializer = serializer;
            _categoryFetcher = categoryFetcher;
            _productProcessor = productProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryFetcher.GetCategoriesAsync();
            
            return new ObjectResult(_serializer.Serialize(categories));
        }

        [HttpGet("{categoryId}/products")]
        public async Task<IActionResult> GetProducts(int categoryId)
        {
            var products = await _productProcessor.GetProductsAsync(categoryId);
            
            return new ObjectResult(_serializer.Serialize(products));
        }
    }
}