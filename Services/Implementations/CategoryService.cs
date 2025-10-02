using Asp_Net_Core_Mvc_Store.Data.Entities;
using Asp_Net_Core_Mvc_Store.Data.Repositories.Base;

namespace Asp_Net_Core_Mvc_Store.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public IList<Category> GetCategoriesByIds(ICollection<int> categoryIds)
        {
            return _categoryRepository.GetAll().Where(c => categoryIds.Contains(c.Id)).ToList();
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetById(categoryId);
        }
    }
}
