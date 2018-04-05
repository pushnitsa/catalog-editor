using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CatalogEditor.Controllers.Api
{
    [Route("api/category")]
    public class CategoryController : Controller
    {

        public CategoryController()
        {
            
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetCategories()
        {
            return new ObjectResult("");
        }
    }
}