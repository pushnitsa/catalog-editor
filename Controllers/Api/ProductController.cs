using System.Threading.Tasks;
using CatalogEditor.Deserializer;
using CatalogEditor.Fetcher;
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
        private readonly IImageFetcher _imageFetcher;
        
        public ProductController(
            ProductProcessor productProcessor, 
            IEntitySerializer serializer,
            IEntityDeserializer deserializer,
            IImageFetcher imageFetcher
        )
        {
            _productProcessor = productProcessor;
            _serializer = serializer;
            _deserializer = deserializer;
            _imageFetcher = imageFetcher;
        }

        [HttpDelete]
        public IActionResult DeleteProducts()
        {
            return new ObjectResult(true);
        }

        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return new ObjectResult("");
        }

        [HttpPost]
        public IActionResult CreateProduct()
        {
            return new ObjectResult("");
        }

        [HttpGet("{productId}/image")]
        public async Task<IActionResult> GetImage(int productId)
        {
            var image = await _imageFetcher.GetFileAsync(productId);
            
            return File(image, _imageFetcher.ContentType);
        }
    }
}