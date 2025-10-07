using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Asp_Net_Core_Mvc_Store.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public required string Name { get; set; }

        [MaxLength(2048)]
        public string? Description { get; set; }

        [MaxLength(512)]
        public string? ImageUrl { get; set; }

        [Precision(9, 2)]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
