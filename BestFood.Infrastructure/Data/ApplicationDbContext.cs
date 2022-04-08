using BestFood.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryIngredient> CategoryIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductIngredient> ProductIngredient { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryIngredient>().HasKey(ci => new { ci.IngredientId, ci.CategoryId });
            builder.Entity<ProductIngredient>().HasKey(pi => new { pi.ProductId, pi.IngredientId });
            builder.Entity<ProductOrder>().HasKey(po => new { po.ProductId, po.OrderId });

            builder.Entity<Order>().Property(o => o.Amount).HasColumnType("decimal(18,4)");
            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,4)");

            base.OnModelCreating(builder);
        }
    }
}