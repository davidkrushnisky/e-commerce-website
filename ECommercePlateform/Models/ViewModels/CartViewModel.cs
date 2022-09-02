namespace ECommercePlateform.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartProduct> CartProducts { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
