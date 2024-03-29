﻿namespace Asm1_WebMVC_vinhttph19362.Models
{
    public class Product
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; }
        public int Status { get; set; } 
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }


    }
}
