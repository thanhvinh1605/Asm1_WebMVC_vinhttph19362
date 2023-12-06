namespace Asm1_WebMVC_vinhttph19362.Models
{
    public class OrderDetails
    {
        public Guid Id { get; set; }    
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float DissacountAmount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
