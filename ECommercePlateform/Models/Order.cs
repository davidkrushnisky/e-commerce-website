namespace ECommercePlateform.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public ICollection<int> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
