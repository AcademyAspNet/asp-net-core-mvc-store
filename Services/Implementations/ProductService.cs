using Asp_Net_Core_Mvc_Store.Models.Entities;

namespace Asp_Net_Core_Mvc_Store.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IList<Product> _products = [
            new Product() { Id = 1, Categories = new HashSet<int> { 1, 2 },  Name = "Товар 1", Price = 100, Image = "/images/templates/cylinder.png", Description = "Описание для товара 1" },
            new Product() { Id = 2, Categories = new HashSet<int> { 1 }, Name = "Товар 2", Price = 200, Image = "/images/templates/tetrahedron.png" },
            new Product() { Id = 3, Categories = new HashSet<int> { 1, 3 }, Name = "Товар 3", Price = 300, Image = "/images/templates/torus.png" }
        ];

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _products.Where(p => p.Categories.Contains(categoryId));
        }

        public Product? GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
