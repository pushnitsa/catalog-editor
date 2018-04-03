using Microsoft.AspNetCore.Mvc;

namespace CatalogEditor.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {

        public HomeController()
        {
            
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}