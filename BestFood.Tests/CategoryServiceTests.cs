using System;
using System.Linq;
using System.Threading.Tasks;
using BestFood.Core.Services;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Category;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BestFood.Tests
{
    public class CategoryServiceTests
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
                .AddSingleton<IRepository<Category>, Repository<Category>>()
                .AddSingleton<ICategoryService, CategoryService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository<Category>>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void UnknownCategoryMustThrow()
        {
            var service = serviceProvider.GetService<ICategoryService>();

            Assert.CatchAsync<ArgumentNullException>(async () => await service.FindById(-123), "Unknown category!");
        }

        [Test]
        public void KnownCategoryMustNotThrow()
        {
            var service = serviceProvider.GetService<ICategoryService>();

            Assert.DoesNotThrowAsync(async () => await service.FindById(1));
        }

        [Test]
        public async Task AllMustReturnAllCategories()
        {
            var service = serviceProvider.GetService<ICategoryService>();

            var categories = await service.All();

            Assert.That(categories.Count() > 0);
        }

        [Test]
        public async Task CreateAsyncMustCreateCategory()
        {
            var service = serviceProvider.GetService<ICategoryService>();
            var repo = serviceProvider.GetService<IRepository<Category>>();

            var categoryViewModel = new CreateCategoryViewModel()
            {
                Name = "NewCategory",
                Image = "https://st2.depositphotos.com/1000339/5752/i/600/depositphotos_57527967-stock-photo-burger-and-french-fries.jpg"
            };

            service.CreateAsync(categoryViewModel);

            Assert.That(repo.All().Any(c => c.Name == categoryViewModel.Name));
        }

        [Test]
        public void DeleteMustThrowOnUnknownCategory()
        {
            var service = serviceProvider.GetService<ICategoryService>();

            Assert.CatchAsync<ArgumentNullException>(async () => await service.Delete(-123), "Unknown category!");
        }

        [Test]
        public async Task DeleteMustDeleteCategory()
        {
            var service = serviceProvider.GetService<ICategoryService>();
            var repo = serviceProvider.GetService<IRepository<Category>>();

            service.Delete(1);

            Assert.That(repo.All().Any(c => c.Id == 1) == false);
        }

        [Test]
        public void EditAsyncMustThrowOnUnknownCategory()
        {
            var service = serviceProvider.GetService<ICategoryService>();

            var editCategoryViewModel = new EditCategoryViewModel()
            {
                Id = -123,
                Name = "NewCategory",
                Image = "https://st2.depositphotos.com/1000339/5752/i/600/depositphotos_57527967-stock-photo-burger-and-french-fries.jpg"
            };

            Assert.CatchAsync<ArgumentNullException>(async () => await service.EditAsync(editCategoryViewModel), "Unknown category!");
        }

        [Test]
        public async Task EditAsyncMustEditCategory()
        {
            var service = serviceProvider.GetService<ICategoryService>();
            var repo = serviceProvider.GetService<IRepository<Category>>();

            var editCategoryViewModel = new EditCategoryViewModel()
            {
                Id = 1,
                Name = "EditedCategory",
                Image = "https://st2.depositphotos.com/1000339/5752/i/600/depositphotos_57527967-stock-photo-burger-and-french-fries.jpg"
            };

            await service.EditAsync(editCategoryViewModel);

            var editedCategory = repo.All().FirstOrDefault(c => c.Id == 1);

            Assert.AreEqual(editCategoryViewModel.Name, editedCategory.Name);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository<Category> repo)
        {
            var category = new Category()
            {
                Id = 1,
                Name = "Burgers",
                Image = "https://images.unsplash.com/photo-1571091718767-18b5b1457add?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8N3x8YnVyZ2VyfGVufDB8fDB8fA%3D%3D&w=1000&q=80"
            };

            if (repo.All().Any(c => c.Id == category.Id) == false)
            {
                await repo.AddAsync(category);
                await repo.SaveChangesAsync();
            }
        }
    }
}