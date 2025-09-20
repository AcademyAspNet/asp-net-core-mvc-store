using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_Mvc_Store.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
