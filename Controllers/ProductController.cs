using Asp_Net_Core_Mvc_Store.Models.Entities;
using Asp_Net_Core_Mvc_Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_Mvc_Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products/{id:int:min(0)}")]
        public IActionResult Index([FromRoute(Name = "id")] int productId)
        {
            Product? product = _productService.GetProductById(productId);

            if (product == null)
                return RedirectToAction(nameof(CategoryController.Categories), nameof(CategoryController).Replace("Controller", ""));

            return View(product);
        }
    }
}
