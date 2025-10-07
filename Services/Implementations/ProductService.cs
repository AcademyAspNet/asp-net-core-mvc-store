using Asp_Net_Core_Mvc_Store.Data;
using Asp_Net_Core_Mvc_Store.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp_Net_Core_Mvc_Store.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _database;

        public ProductService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            Category? category = _database.Categories.Include(c => c.Products)
                                                     .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
                return [];

            return category.Products;
        }

        public Product? GetProductById(int productId)
        {
            return _database.Products.Include(p => p.Categories)
                                     .FirstOrDefault(p => p.Id == productId);
        }
    }
}
