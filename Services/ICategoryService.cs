using Asp_Net_Core_Mvc_Store.Models.Entities;

namespace Asp_Net_Core_Mvc_Store.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category? GetCategoryById(int categoryId);
    }
}
