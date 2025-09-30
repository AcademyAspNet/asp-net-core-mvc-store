using Asp_Net_Core_Mvc_Store.Data.Entities;
using Asp_Net_Core_Mvc_Store.Models.ViewModels;
using Asp_Net_Core_Mvc_Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_Mvc_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        [Route("categories")]
        public IActionResult Categories()
        {
            IEnumerable<Category> categories = _categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        [Route("categories/{id:int:min(0)}/products")]
        public IActionResult ProductsByCategory([FromRoute(Name = "id")] int categoryId)
        {
            Category? category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
                return RedirectToAction(nameof(Categories));

            CategoryViewModel model = new CategoryViewModel()
            {
                Category = category,
                Products = _productService.GetProductsByCategoryId(categoryId)
            };

            return View(model);
        }
    }
}
