using Asp_Net_Core_Mvc_Store.Data.Entities;
using Asp_Net_Core_Mvc_Store.Data.Repositories;
using Asp_Net_Core_Mvc_Store.Data.Repositories.Base;

namespace Asp_Net_Core_Mvc_Store.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            if (_productRepository is ProductRepository productRepository)
                return productRepository.GetByCategoryId(categoryId);

            return [];
        }

        public Product? GetProductById(int productId)
        {
            return _productRepository.GetById(productId);
        }
    }
}
