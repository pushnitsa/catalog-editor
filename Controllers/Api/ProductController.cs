using System.Threading.Tasks;
using CatalogEditor.Deserializer;
using CatalogEditor.Processor;
using CatalogEditor.Serializer;
using Microsoft.AspNetCore.Mvc;

namespace CatalogEditor.Controllers.Api
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ProductProcessor _productProcessor;
        private readonly IEntitySerializer _serializer;
        private readonly IEntityDeserializer _deserializer;
        
        public ProductController(
            ProductProcessor productProcessor, 
            IEntitySerializer serializer,
            IEntityDeserializer deserializer
        )
        {
            _productProcessor = productProcessor;
            _serializer = serializer;
            _deserializer = deserializer;
        }

        [HttpGet("get/{categoryId}")]
        public async Task<IActionResult> GetProducts(int categoryId)
        {
            var products = await _productProcessor.GetProductsAsync(categoryId);
            
            return new ObjectResult(_serializer.Serialize(products));
        }

        [HttpDelete]
        public IActionResult DeleteProducts()
        {
            return new ObjectResult(true);
        }

        [HttpPut()]
        public IActionResult UpdateProduct()
        {
            return new ObjectResult("");
        }

        [HttpPost]
        public IActionResult CreateProduct()
        {
            return new ObjectResult("");
        }
    }
}