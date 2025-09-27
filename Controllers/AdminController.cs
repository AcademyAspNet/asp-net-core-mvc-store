using Asp_Net_Core_Mvc_Store.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_Mvc_Store.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("admin")]
        [AuthFilter("qwerty")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
