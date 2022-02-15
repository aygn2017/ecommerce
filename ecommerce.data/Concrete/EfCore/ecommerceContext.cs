using ecommerce.data.Configurations;
using ecommerce.entity;
using Microsoft.EntityFrameworkCore;


namespace ecommerce.data.Concrete.EfCore
{
    public class ecommerceContext : DbContext
    {
        public ecommerceContext()
        {

        }
        public ecommerceContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            string constr = @"server=(localdb)\MSSQLLocalDB;Database=ecommerceDb;Trusted_Connection=true";
            optionsBuilder.UseSqlServer(constr);
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());

            modelBuilder.Seed();
        }


    }
}