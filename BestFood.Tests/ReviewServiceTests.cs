using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Core.Services;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Review;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using BestFood.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BestFood.Tests
{
    public class ReviewServiceTests
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
                .AddSingleton<IRepository<Review>, Repository<Review>>()
                .AddSingleton<IRepository<CategoryIngredient>, Repository<CategoryIngredient>>()
                .AddSingleton<IReviewService, ReviewService>()
                .BuildServiceProvider();

            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();
            var productRepo = serviceProvider.GetService<IRepository<Product>>();
            var categoryRepo = serviceProvider.GetService<IRepository<Category>>();
            var ingredientRepo = serviceProvider.GetService<IRepository<Ingredient>>();
            var categoryIngredientRepo = serviceProvider.GetService<IRepository<CategoryIngredient>>();
            var reviewRepo = serviceProvider.GetService<IRepository<Review>>();

            await SeedDbAsync(userRepo, productRepo, categoryRepo, ingredientRepo, categoryIngredientRepo, reviewRepo);
        }

        [Test]
        public void RateProdcutAsyncMustThrowOnUknownUser()
        {
            var service = serviceProvider.GetService<IReviewService>();

            var createReviewViewModel = new CreateReviewViewModel()
            {
                Text = "TestReview",
                Rating = 3,
                ProductId = "0f0055eb-b982-440f-b7af-c43eb6bfab22"
            };

            Assert.CatchAsync<ArgumentNullException>(async () => await service.RateProdcutAsync(createReviewViewModel, "asdas"), "Unknown user!");
        }

        [Test]
        public void RateProdcutAsyncMustThrowOnUknownProductId()
        {
            var service = serviceProvider.GetService<IReviewService>();

            var createReviewViewModel = new CreateReviewViewModel()
            {
                Text = "TestReview",
                Rating = 3,
                ProductId = "asdas"
            };

            Assert.CatchAsync<ArgumentNullException>(async () => await service.RateProdcutAsync(createReviewViewModel, "angel@gmail.com"), "Unknown product id!");
        }

        [Test]
        public async Task RateProdcutAsyncMustCreateReviewToGivenProduct()
        {
            var service = serviceProvider.GetService<IReviewService>();
            var reviewRepo = serviceProvider.GetService<IRepository<Review>>();
            var productRepo = serviceProvider.GetService<IRepository<Product>>();

            var createReviewViewModel = new CreateReviewViewModel()
            {
                Text = "TestReview",
                Rating = 3,
                ProductId = "0f0055eb-b982-440f-b7af-c43eb6bfab22"
            };

            await service.RateProdcutAsync(createReviewViewModel, "angel@gmail.com");

            Assert.That(reviewRepo.All().Any(r => r.ApplicationUserId == "83a52d86-0f92-49b1-9bed-9910a722d4f5"));
            Assert.That(reviewRepo.All().Any(r => r.Text == "TestReview"));
            Assert.That(reviewRepo.All().Any(r => r.ProductId == "0f0055eb-b982-440f-b7af-c43eb6bfab22"));
            Assert.That(productRepo.All().First(p => p.Id == "0f0055eb-b982-440f-b7af-c43eb6bfab22").Reviews.Any(r => r.Text == "TestReview"));
        }

        [Test]
        public void FindByIdAsyncMustThrowOnUknownReviewId()
        {
            var service = serviceProvider.GetService<IReviewService>();

            Assert.CatchAsync<ArgumentNullException>(async () => await service.FindByIdAsync("asd"), "Unknown review!");
        }

        [Test]
        public async Task FindByIdAsyncMustReturnEditReviewViewModelProperly()
        {
            var service = serviceProvider.GetService<IReviewService>();



            var editReviewViewModel = await service.FindByIdAsync("211f9961-e286-402b-a01c-e3d5117b5cb6");

            Assert.That(editReviewViewModel.Id == "211f9961-e286-402b-a01c-e3d5117b5cb6");
            Assert.That(editReviewViewModel.Text == "MyReview");
            Assert.That(editReviewViewModel.Rating == 4);
            Assert.That(editReviewViewModel.ProductId == "0f0055eb-b982-440f-b7af-c43eb6bfab22");
        }

        [Test]
        public void DeleteMustThrowOnUknownReviewId()
        {
            var service = serviceProvider.GetService<IReviewService>();

            Assert.CatchAsync<ArgumentNullException>(async () => await service.Delete("asd"), "Unknown review!");
        }

        [Test]
        public async Task DeleteMustDeleteReviewWhenIdIsValid()
        {
            var service = serviceProvider.GetService<IReviewService>();
            var reviewRepo = serviceProvider.GetService<IRepository<Review>>();

            await service.Delete("211f9961-e286-402b-a01c-e3d5117b5cb6");

            Assert.That(reviewRepo.All().Any(r => r.Id == "211f9961-e286-402b-a01c-e3d5117b5cb6") == false);
        }

        [Test]
        public void EditAsyncMustThrowOnUknownReviewId()
        {
            var service = serviceProvider.GetService<IReviewService>();

            var editReviewViewModel = new EditReviewViewModel()
            {
                Id = "sad",
                Text = "EditedText",
                Rating = 1,
                ProductId = "0f0055eb-b982-440f-b7af-c43eb6bfab22"
            };

            Assert.CatchAsync<ArgumentNullException>(async () => await service.EditAsync(editReviewViewModel), "Unknown review!");
        }

        [Test]
        public async Task EditAsyncMustEditReviewWhenIdIsValid()
        {
            var service = serviceProvider.GetService<IReviewService>();
            var reviewRepo = serviceProvider.GetService<IRepository<Review>>();

            var editReviewViewModel = new EditReviewViewModel()
            {
                Id = "211f9961-e286-402b-a01c-e3d5117b5cb6",
                Text = "EditedText",
                Rating = 1,
                ProductId = "0f0055eb-b982-440f-b7af-c43eb6bfab22"
            };

            await service.EditAsync(editReviewViewModel);

            var editedReview = reviewRepo.All().First(r => r.Id == "211f9961-e286-402b-a01c-e3d5117b5cb6");

            Assert.That(editedReview.Text== editReviewViewModel.Text);
            Assert.That(editedReview.Rating== editReviewViewModel.Rating);
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
            IRepository<Review> reviewRepo)
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

            var review = new Review()
            {
                Id = "211f9961-e286-402b-a01c-e3d5117b5cb6",
                ApplicationUserId = "83a52d86-0f92-49b1-9bed-9910a722d4f5",
                Text = "MyReview",
                Rating = 4,
                Date = DateTime.Now,
                ProductId = "0f0055eb-b982-440f-b7af-c43eb6bfab22"
            };

            if (reviewRepo.All().Any(r => r.Id == review.Id) == false)
            {
                await reviewRepo.AddAsync(review);
                await reviewRepo.SaveChangesAsync();
            }
        }
    }
}
