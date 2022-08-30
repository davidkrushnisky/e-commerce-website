using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlateform.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public ApplicationUser User { get; set; }
        public Product Product { get; set; }

        //many-to-many
        //public ICollection<Product> Products { get; set; }

    }
}
