using System.Threading.Tasks;
using CatalogEditor.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogEditor.Controllers.Api
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IContextFactory _contextFactory;
        
        public ProductController(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet("get/{categoryId}")]
        public async Task GetProducts(int categoryId)
        {
            using (var context = _contextFactory.Create())
            {
                var productList = await context.Products.ToListAsync();
            }
        }
    }
}