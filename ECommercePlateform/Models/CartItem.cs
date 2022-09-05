using System.ComponentModel.DataAnnotations;

namespace ECommercePlateform.Models
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public byte[] Picture { get; set; }
        public int Count { get; set; }

        //The Stock Quantity
        public int Quantity { get; set; }
        public Product product { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Price * Count;
            }
        }

        public CartItem() { }

        public CartItem(Product product)
        {
            ItemId = product.ProductId;
            Name = product.Name;
            Price = product.Price;
            Color = product.Color;
            Picture = product.Pictures;
            Quantity = product.Quantity;
        }
    }
}
