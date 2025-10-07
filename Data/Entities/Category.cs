using System.ComponentModel.DataAnnotations;

namespace Asp_Net_Core_Mvc_Store.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public required string Name { get; set; }

        [MaxLength(512)]
        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
