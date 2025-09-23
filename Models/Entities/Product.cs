namespace Asp_Net_Core_Mvc_Store.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public ISet<int> Categories { get; set; } = new HashSet<int>();

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public decimal Price { get; set; }
    }
}
