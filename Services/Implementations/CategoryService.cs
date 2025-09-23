using Asp_Net_Core_Mvc_Store.Models.Entities;

namespace Asp_Net_Core_Mvc_Store.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IList<Category> _categories = [
            new Category() { Id = 1, Name = "Категория 1", Image = "/images/templates/cube.png" },
            new Category() { Id = 2, Name = "Категория 2", Image = "/images/templates/sphere.png" },
            new Category() { Id = 3, Name = "Категория 3", Image = "/images/templates/cone.png" }
        ];

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.Id == categoryId);
        }
    }
}
