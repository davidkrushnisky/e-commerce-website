using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlateform.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public ApplicationUser User { get; set; }

        [InverseProperty("UserId")]
        public int UserId { get; set; }

        //many-to-many
        [InverseProperty("ProductId")]
        public ICollection<Product> Products { get; set; }
    }
}
