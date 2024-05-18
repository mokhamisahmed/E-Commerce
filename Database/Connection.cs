using E_Commerce_WebSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebSite.Database
{
    public class Connection:IdentityDbContext<ApplicationUser>
    {
        public Connection(DbContextOptions<Connection> option) : base(option)
        {


        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

       


        




    }
}
