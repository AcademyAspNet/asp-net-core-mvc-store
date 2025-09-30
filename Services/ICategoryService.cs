using Asp_Net_Core_Mvc_Store.Data.Entities;

namespace Asp_Net_Core_Mvc_Store.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        IList<Category> GetCategoriesByIds(ICollection<int> categoryIds);
        Category? GetCategoryById(int categoryId);
    }
}
