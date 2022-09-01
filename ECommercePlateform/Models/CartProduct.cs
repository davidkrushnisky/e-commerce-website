namespace ECommercePlateform.Models
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public byte[] Picture { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }

        public CartProduct() {}

        public CartProduct(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Price = product.Price;
            Color = product.Color;
            Picture = product.Pictures;
            Quantity = 1;
        }
    }
}
