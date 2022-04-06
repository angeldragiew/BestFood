using System;
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
    public class Tests
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
                Image = ""
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }
    }
}