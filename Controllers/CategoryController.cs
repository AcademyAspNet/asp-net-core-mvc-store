using Asp_Net_Core_Mvc_Store.Models.Entities;
using Asp_Net_Core_Mvc_Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Net_Core_Mvc_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("categories")]
        public IActionResult Categories()
        {
            IEnumerable<Category> categories = _categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        [Route("categories/{id:int:min(0)}")]
        public IActionResult Category([FromRoute] int id)
        {
            Category? category = _categoryService.GetCategoryById(id);

            if (category == null)
                return RedirectToAction(nameof(Categories));

            return Content($"Название выбранной категории: {category.Name}, её идентификатор: {category.Id}");
        }
    }
}
