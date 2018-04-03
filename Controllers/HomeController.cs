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
        public async void Index()
        {
            
        }
    }
}