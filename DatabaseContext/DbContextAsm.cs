using Asm1_WebMVC_vinhttph19362.Models;
using Microsoft.EntityFrameworkCore;

namespace Asm1_WebMVC_vinhttph19362.DatabaseContext
{
    public class DbContextAsm:DbContext
    {
        public DbContextAsm(DbContextOptions<DbContextAsm> options) :base(options)
        {

        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
