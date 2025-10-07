using Asp_Net_Core_Mvc_Store.Data.Entities;

namespace Asp_Net_Core_Mvc_Store.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category? GetCategoryById(int categoryId);
    }
}
