using BestFood.Core.ViewModels.Ingredient;
using System.Threading.Tasks;
using BestFood.Core.Services;
using BestFood.Core.Services.Contracts;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;
using BestFood.Infrastructure.Enums;
using System.Collections.Generic;
using System;

namespace BestFood.Tests
{
    public class IngredientServiceTests
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
                .AddSingleton<IRepository<Ingredient>, Repository<Ingredient>>()
                .AddSingleton<IRepository<Category>, Repository<Category>>()
                .AddSingleton<IRepository<CategoryIngredient>, Repository<CategoryIngredient>>()
                .AddSingleton<IIngredientService, IngredientService>()
                .BuildServiceProvider();

            var ingredientRepo = serviceProvider.GetService<IRepository<Ingredient>>();
            var categoryRepo = serviceProvider.GetService<IRepository<Category>>();
            var categoryIngredientRepo = serviceProvider.GetService<IRepository<CategoryIngredient>>();
            await SeedDbAsync(ingredientRepo, categoryRepo, categoryIngredientRepo);
        }

        [Test]
        public async Task AllMustReturnAllIngredients()
        {
            var service = serviceProvider.GetService<IIngredientService>();

            var ingredients = await service.All();

            Assert.That(ingredients.Count() > 0);
        }

        [Test]
        public async Task CreateAsyncMustCreateIngredient()
        {
            var service = serviceProvider.GetService<IIngredientService>();
            var repo = serviceProvider.GetService<IRepository<Ingredient>>();

            var ingredientViewModel = new CreateIngredientViewModel()
            {
                Name = "CreatedIngredient",
                Type = IngredientType.Sauce,
                CategoryIds = new List<int>() { 1, 2 }
            };


            await service.CreateAsync(ingredientViewModel);

            Assert.That(repo.All().Any(c => c.Name == ingredientViewModel.Name));
        }

        [Test]
        public async Task CreateAsyncMustSetIngredientCategoriesAndTypeProperly()
        {
            var service = serviceProvider.GetService<IIngredientService>();
            var repo = serviceProvider.GetService<IRepository<Ingredient>>();

            var ingredientViewModel = new CreateIngredientViewModel()
            {
                Name = "CreatedIngredient",
                Type = IngredientType.Sauce,
                CategoryIds = new List<int>() { 1, 2 }
            };


            await service.CreateAsync(ingredientViewModel);

            var createdIngredient = repo.All().First(c => c.Name == ingredientViewModel.Name);

            Assert.That(createdIngredient.CategoryIngredients.Any(ci => ci.CategoryId == 1));
            Assert.That(createdIngredient.CategoryIngredients.Any(ci => ci.CategoryId == 2));
            Assert.That(createdIngredient.Type == ingredientViewModel.Type);
        }

        [Test]
        public void DeleteMustThrowOnUnknownIngredient()
        {
            var service = serviceProvider.GetService<IIngredientService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.Delete("sadd"), "Unknown ingredient!");
        }

        [Test]
        public async Task DeleteMustDeleteIngredient()
        {
            var service = serviceProvider.GetService<IIngredientService>();
            var repo = serviceProvider.GetService<IRepository<Ingredient>>();

            service.Delete("64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778");

            Assert.That(repo.All().Any(c => c.Id == "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778") == false);
        }

        [Test]
        public void EditAsyncMustThrowOnUnknownIngredient()
        {
            var service = serviceProvider.GetService<IIngredientService>();

            var editIngredientViewModel = new EditIngredientViewModel()
            {
                Id = "sadassad",
                Name = "EditIngredient",
                Type = IngredientType.Sauce
            };

            Assert.CatchAsync<ArgumentException>(async () => await service.EditAsync(editIngredientViewModel), "Unknown ingredient!");
        }

        [Test]
        public async Task EditAsyncMustEditIngredient()
        {
            var service = serviceProvider.GetService<IIngredientService>();
            var repo = serviceProvider.GetService<IRepository<Ingredient>>();

            var editIngredientViewModel = new EditIngredientViewModel()
            {
                Id = "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778",
                Name = "EditedIngredient",
                Type = IngredientType.Sauce,
                CategoryIds = new List<int>() { 1 }
            };

            await service.EditAsync(editIngredientViewModel);

            var editedIngredient = repo.All().FirstOrDefault(i => i.Id == "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778");

            Assert.That(editedIngredient.CategoryIngredients.Any(ci => ci.CategoryId == 1));
            Assert.That(editedIngredient.CategoryIngredients.Any(ci => ci.CategoryId == 2) == false);
            Assert.That(editedIngredient.Type == editIngredientViewModel.Type);
        }

        [Test]
        public async Task EditAsyncMustSetIngredientTypeAndCategoriesProperly()
        {
            var service = serviceProvider.GetService<IIngredientService>();
            var repo = serviceProvider.GetService<IRepository<Ingredient>>();

            var editIngredientViewModel = new EditIngredientViewModel()
            {
                Id = "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778",
                Name = "EditedIngredient",
                Type = IngredientType.Meat,
                CategoryIds = new List<int>() { 1 }
            };

            await service.EditAsync(editIngredientViewModel);

            var editedIngredient = repo.All().FirstOrDefault(i => i.Id == "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778");

            Assert.AreEqual(editIngredientViewModel.Name, editedIngredient.Name);
        }

        [Test]
        public void UnknownIngredientMustThrow()
        {
            var service = serviceProvider.GetService<IIngredientService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.FindById("sadasd1231ads"), "Unknown ingredient!");
        }

        [Test]
        public void KnownIngredientMustNotThrow()
        {
            var service = serviceProvider.GetService<IIngredientService>();

            Assert.DoesNotThrowAsync(async () => await service.FindById("64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778"));
        }

        [Test]
        public async Task LoadCategoriesForCreateMustReturnAllAvailableCategories()
        {
            var service = serviceProvider.GetService<IIngredientService>();

            var ingredientCategoryViewModels = await service.LoadCategoriesForCreate();

            Assert.That(ingredientCategoryViewModels.Count() > 0);

            foreach (var ingredientCategoryViewModel in ingredientCategoryViewModels)
            {
                Assert.AreEqual(ingredientCategoryViewModel.IsSelected, false);
            }
        }

        [Test]
        public async Task LoadCategoriesForEditMustReturnAllAvailableAndSelectedCategories()
        {
            var service = serviceProvider.GetService<IIngredientService>();

            var ingredientCategoryViewModels = await service.LoadCategoriesForEdit("64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778");
            var selectedCategoryIngredient = ingredientCategoryViewModels.First(ic => ic.CategoryId == 1);

            Assert.That(ingredientCategoryViewModels.Count() > 0);
            Assert.AreEqual(selectedCategoryIngredient.IsSelected, true);
        }

        [Test]
        public async Task SaveSubmittedCategoryValuesMustSaveSubmitted()
        {
            var service = serviceProvider.GetService<IIngredientService>();

            List<IngredientCategoryViewModel> categories = new List<IngredientCategoryViewModel>
            {
                new IngredientCategoryViewModel()
                {
                    CategoryId=1,
                    CategoryName="Burger",
                    IsSelected=false,
                },
                new IngredientCategoryViewModel()
                {
                    CategoryId=2,
                    CategoryName="Pizza",
                    IsSelected=true,
                },
            };

            List<int> categoryIds = new List<int> { 1 };

            service.SaveSubmittedCategoryValues(categories, categoryIds);


            Assert.AreEqual(true, categories[0].IsSelected);
            Assert.AreEqual(false, categories[1].IsSelected);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository<Ingredient> ingredientRepo,
            IRepository<Category> categoryRepo,
            IRepository<CategoryIngredient> categoryIngredientRepo)
        {
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

            var categoryIngredient = new CategoryIngredient()
            {
                CategoryId = 1,
                IngredientId = "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778"
            };

            if (categoryIngredientRepo.All().Any(ci => ci.CategoryId == categoryIngredient.CategoryId && ci.IngredientId == categoryIngredient.IngredientId == false))
            {
                await categoryIngredientRepo.AddAsync(categoryIngredient);
                await categoryIngredientRepo.SaveChangesAsync();
            }
        }
    }
}
