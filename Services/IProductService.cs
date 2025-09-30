using Asp_Net_Core_Mvc_Store.Data.Entities;

namespace Asp_Net_Core_Mvc_Store.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        Product? GetProductById(int productId);
    }
}
