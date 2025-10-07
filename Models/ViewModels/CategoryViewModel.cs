using Asp_Net_Core_Mvc_Store.Data.Entities;

namespace Asp_Net_Core_Mvc_Store.Models.ViewModels
{
    public class CategoryViewModel
    {
        public required Category Category { get; set; }
        public required IEnumerable<Product> Products { get; set; }
    }
}
