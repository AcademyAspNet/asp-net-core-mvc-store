using Asp_Net_Core_Mvc_Store.Data;
using Asp_Net_Core_Mvc_Store.Data.Entities;
using System.Collections.Immutable;

namespace Asp_Net_Core_Mvc_Store.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _database;

        public CategoryService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _database.Categories.ToImmutableList();
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _database.Categories.Find(categoryId);
        }
    }
}
