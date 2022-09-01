namespace ECommercePlateform.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartProduct> CartProducts { get; set; }
        /*public int ProductCount { get; set; }*/
        public decimal TotalPrice { get; set; }

    }
}
