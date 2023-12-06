namespace Asm1_WebMVC_vinhttph19362.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
