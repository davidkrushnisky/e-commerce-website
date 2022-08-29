namespace ECommercePlateform.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public ICollection<int> CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public ICollection<byte[]> Picture { get; set; } //1 or multiple picture?
        public string description { get; set; }
    }
}
