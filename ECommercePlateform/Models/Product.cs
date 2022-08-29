﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ECommercePlateform.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public ICollection<byte[]> Pictures { get; set; }
        public string Description { get; set; }
        
        [ForeignKey(nameof(Category))]
        public Category? Category { get; set; }

        [ForeignKey(nameof(Order))]
        public ICollection<Order> Orders { get; set; }
    }
}
