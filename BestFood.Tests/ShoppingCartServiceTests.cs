using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Core.Services;
using BestFood.Core.Services.Contracts;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using BestFood.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BestFood.Tests
{
    public class ShoppingCartServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository<ApplicationUser>, Repository<ApplicationUser>>()
                .AddSingleton<IRepository<Category>, Repository<Category>>()
                .AddSingleton<IRepository<Product>, Repository<Product>>()
                .AddSingleton<IRepository<Ingredient>, Repository<Ingredient>>()
                .AddSingleton<IRepository<CategoryIngredient>, Repository<CategoryIngredient>>()
                .AddSingleton<IRepository<CartItem>, Repository<CartItem>>()
                .AddSingleton<IShoppingCartService, ShoppingCartService>()
                .BuildServiceProvider();

            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();
            var productRepo = serviceProvider.GetService<IRepository<Product>>();
            var categoryRepo = serviceProvider.GetService<IRepository<Category>>();
            var ingredientRepo = serviceProvider.GetService<IRepository<Ingredient>>();
            var categoryIngredientRepo = serviceProvider.GetService<IRepository<CategoryIngredient>>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();

            await SeedDbAsync(userRepo, productRepo, categoryRepo, ingredientRepo, categoryIngredientRepo, cartItemRepo);
        }


        [Test]
        public void AddItemToCartAsyncMustThrowOnUnknownProductId()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.AddItemToCartAsync("angel", "asdas"), "Product id is not valid!");
        }

        [Test]
        public async Task AddItemToCartAsyncShouldCreateCartItemIfCartItemDoesntExist()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();

            await service.AddItemToCartAsync("test", "0f0055eb-b982-440f-b7af-c43eb6bfab22");

            var createdCartItem = cartItemRepo.All().FirstOrDefault(c => c.CartId == "test" && c.ProductId == "0f0055eb-b982-440f-b7af-c43eb6bfab22");

            Assert.That(createdCartItem != null);
            Assert.AreEqual(1, createdCartItem.Quantity);
        }

        [Test]
        public async Task AddItemToCartAsyncShouldIncreaseCartItemQuantityIfItExists()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();

            await service.AddItemToCartAsync("angel", "0f0055eb-b982-440f-b7af-c43eb6bfab22");

            var createdCartItem = cartItemRepo.All().FirstOrDefault(c => c.CartId == "angel" && c.ProductId == "0f0055eb-b982-440f-b7af-c43eb6bfab22");

            Assert.That(createdCartItem != null);
            Assert.AreEqual(2, createdCartItem.Quantity);
        }


        [Test]
        public async Task AllAsyncShouldReturnAllCartItemsForGivenCart()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();

            var allCartItems = await service.AllAsync("angel");

            Assert.That(allCartItems.Count() > 0);
            foreach (var cartItem in allCartItems)
            {
                Assert.That(cartItemRepo.All().FirstOrDefault(c => c.ItemId == cartItem.Id).CartId == "angel");
            }
        }

        [Test]
        public async Task ClearCartMustDeleteAllCartItemsWithGivenCartId()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();

            await service.ClearCart("angel");

            Assert.That(cartItemRepo.All().Any(c => c.CartId == "angel") == false);
        }

        [Test]
        public void IncreaseQuantityAsyncMustThrowOnUnknownCartItemIdOrCart()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.IncreaseQuantityAsync("asd", "angel"), "Unknown cart item!");
            Assert.CatchAsync<ArgumentException>(async () => await service.IncreaseQuantityAsync("c42d317e-7a84-4230-819d-e23a4b9bb0cf", "angsadasel"), "Unknown cart item!");
        }
        [Test]
        public async Task IncreaseQuantityAsyncMustIncreaseQuantity()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();

            var quantityBefore = cartItemRepo.All().FirstOrDefault(c => c.CartId == "angel" && c.ItemId == "c42d317e-7a84-4230-819d-e23a4b9bb0cf").Quantity;

            await service.IncreaseQuantityAsync("c42d317e-7a84-4230-819d-e23a4b9bb0cf", "angel");

            Assert.That(cartItemRepo.All().FirstOrDefault(c => c.CartId == "angel" && c.ItemId == "c42d317e-7a84-4230-819d-e23a4b9bb0cf").Quantity > quantityBefore);
        }

        [Test]
        public void DecreaseQuantityAsyncMustThrowOnUnknownCartItemIdOrCart()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.DecreaseQuantityAsync("asd", "angel"), "Unknown cart item!");
            Assert.CatchAsync<ArgumentException>(async () => await service.DecreaseQuantityAsync("c42d317e-7a84-4230-819d-e23a4b9bb0cf", "angsadasel"), "Unknown cart item!");
        }

        [Test]
        public async Task DecreaseQuantityAsyncMustDecreaseQuantity()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();

            var quantityBefore = cartItemRepo.All().FirstOrDefault(c => c.CartId == "ivan" && c.ItemId == "6e4ab009-bf16-470c-aabf-2743c9e3fb63").Quantity;

            await service.DecreaseQuantityAsync("6e4ab009-bf16-470c-aabf-2743c9e3fb63", "ivan");

            Assert.That(cartItemRepo.All().FirstOrDefault(c => c.CartId == "ivan" && c.ItemId == "6e4ab009-bf16-470c-aabf-2743c9e3fb63").Quantity < quantityBefore);
        }

        [Test]
        public async Task DecreaseQuantityAsyncMustDeleteCartItemWhenQuantityIsOne()
        {
            var service = serviceProvider.GetService<IShoppingCartService>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();

            await service.DecreaseQuantityAsync("c42d317e-7a84-4230-819d-e23a4b9bb0cf", "angel");

            Assert.That(cartItemRepo.All().Any(c => c.CartId == "angel" && c.ItemId == "c42d317e-7a84-4230-819d-e23a4b9bb0cf") == false);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository<ApplicationUser> userRepo,
            IRepository<Product> productRepo,
            IRepository<Category> categoryRepo,
            IRepository<Ingredient> ingredientRepo,
            IRepository<CategoryIngredient> categoryIngredientRepo,
            IRepository<CartItem> cartItemRepo)
        {

            var user = new ApplicationUser
            {
                Id = "83a52d86-0f92-49b1-9bed-9910a722d4f5", // primary key
                UserName = "angel@gmail.com",
                NormalizedUserName = "ANGEL@GMAIL.COM",
                Email = "angel@gmail.com",
                NormalizedEmail = "ANGEL@GMAIL.COM"
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            var hashed = hasher.HashPassword(user, "Angel12345.");
            user.PasswordHash = hashed;

            if (userRepo.All().Any(u => u.Id == user.Id) == false)
            {
                await userRepo.AddAsync(user);
                await userRepo.SaveChangesAsync();
            }

            var burgerCategory = new Category()
            {
                Id = 1,
                Name = "Burgers",
                Image = "https://images.unsplash.com/photo-1571091718767-18b5b1457add?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8N3x8YnVyZ2VyfGVufDB8fDB8fA%3D%3D&w=1000&q=80"
            };

            if (categoryRepo.All().Any(c => c.Id == burgerCategory.Id) == false)
            {
                await categoryRepo.AddAsync(burgerCategory);
                await categoryRepo.SaveChangesAsync();
            }

            var pizzaCategory = new Category()
            {
                Id = 2,
                Name = "Pizza",
                Image = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg"
            };

            if (categoryRepo.All().Any(c => c.Id == pizzaCategory.Id) == false)
            {
                await categoryRepo.AddAsync(pizzaCategory);
                await categoryRepo.SaveChangesAsync();
            }


            var ingredient = new Ingredient()
            {
                Id = "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778",
                Name = "TestIngredient",
                Type = IngredientType.Sauce,
            };

            if (ingredientRepo.All().Any(i => i.Id == ingredient.Id) == false)
            {
                await ingredientRepo.AddAsync(ingredient);
                await ingredientRepo.SaveChangesAsync();
            }

            var ingredientTwo = new Ingredient()
            {
                Id = "0c6bc544-e4b4-4c1c-a9a8-acbbd6bbc88c",
                Name = "TestIngredientTwo",
                Type = IngredientType.Sauce,
            };

            if (ingredientRepo.All().Any(i => i.Id == ingredientTwo.Id) == false)
            {
                await ingredientRepo.AddAsync(ingredientTwo);
                await ingredientRepo.SaveChangesAsync();
            }

            var categoryIngredient = new CategoryIngredient()
            {
                CategoryId = 1,
                IngredientId = "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778"
            };

            if (categoryIngredientRepo.All().Any(ci => ci.CategoryId == categoryIngredient.CategoryId && ci.IngredientId == categoryIngredient.IngredientId) == false)
            {
                await categoryIngredientRepo.AddAsync(categoryIngredient);
                await categoryIngredientRepo.SaveChangesAsync();
            }

            var product = new Product()
            {
                Id = "0f0055eb-b982-440f-b7af-c43eb6bfab22",
                Name = "MyTestProduct",
                CategoryId = 1,
                Price = 4.50M,
                Image = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg",
                WeightInGrams = 300,
            };

            if (productRepo.All().Any(p => p.Id == product.Id) == false)
            {
                await productRepo.AddAsync(product);
                await productRepo.SaveChangesAsync();
            }

            var cartItem = new CartItem()
            {
                ItemId = "c42d317e-7a84-4230-819d-e23a4b9bb0cf",
                CartId = "angel",
                ProductId = "0f0055eb-b982-440f-b7af-c43eb6bfab22",
                Quantity = 1
            };

            if (cartItemRepo.All().Any(c => c.ItemId == cartItem.ItemId) == false)
            {
                await cartItemRepo.AddAsync(cartItem);
                await cartItemRepo.SaveChangesAsync();
            }

            var cartItemTwo = new CartItem()
            {
                ItemId = "6e4ab009-bf16-470c-aabf-2743c9e3fb63",
                CartId = "ivan",
                ProductId = "0f0055eb-b982-440f-b7af-c43eb6bfab22",
                Quantity = 2
            };

            if (cartItemRepo.All().Any(c => c.ItemId == cartItemTwo.ItemId) == false)
            {
                await cartItemRepo.AddAsync(cartItemTwo);
                await cartItemRepo.SaveChangesAsync();
            }
        }
    }
}
