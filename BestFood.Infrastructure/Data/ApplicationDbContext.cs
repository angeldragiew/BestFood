using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.InitialSeed;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryIngredient>().HasKey(ci => new { ci.IngredientId, ci.CategoryId });
            builder.Entity<ProductIngredient>().HasKey(pi => new { pi.ProductId, pi.IngredientId });

            builder.Entity<Order>().Property(o => o.Amount).HasColumnType("decimal(18,4)");
            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,4)");

            builder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "8881f953-e7cc-4d0d-8937-9a74413e60c5", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "df578c9e-41dc-48e6-b352-5f4f33577c63", Name = "User", NormalizedName = "USER".ToUpper() });

            var user = new ApplicationUser
            {
                Id = "bcc9e639-b998-466b-8d67-5e7dda1dfe5a", // primary key
                UserName = "myadmin",
                NormalizedUserName = "MYADMIN",
                Email = "myadmin@gmail.com",
                NormalizedEmail = "MYADMIN@GMAIL.COM"
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            var hashed = hasher.HashPassword(user, "MyAdmin12345.");
            user.PasswordHash = hashed;

            builder.Entity<ApplicationUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "8881f953-e7cc-4d0d-8937-9a74413e60c5",
                UserId = "bcc9e639-b998-466b-8d67-5e7dda1dfe5a"
            }
        );

            builder.ApplyConfiguration(new InitialDataConfiguration<Category>(@"InitialSeed/categories.json"));
            builder.ApplyConfiguration(new InitialDataConfiguration<Ingredient>(@"InitialSeed/ingredients.json"));
            builder.ApplyConfiguration(new InitialDataConfiguration<CategoryIngredient>(@"InitialSeed/categoryIngredients.json"));
            builder.ApplyConfiguration(new InitialDataConfiguration<Product>(@"InitialSeed/products.json"));
            builder.ApplyConfiguration(new InitialDataConfiguration<ProductIngredient>(@"InitialSeed/productIngredient.json"));

            base.OnModelCreating(builder);
        }
    }
}