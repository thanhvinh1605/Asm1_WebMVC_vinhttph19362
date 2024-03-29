﻿namespace Asm1_WebMVC_vinhttph19362.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ShoppingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public float TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
