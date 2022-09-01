namespace ECommercePlateform.Models.ViewModels
{
    public class FullCartViewModel
    {
        public List<CartProduct> CartProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
