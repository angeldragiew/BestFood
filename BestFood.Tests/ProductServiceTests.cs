using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Core.Services;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Product;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using BestFood.Infrastructure.Enums;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BestFood.Tests
{
    public class ProductServiceTests
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
                .AddSingleton<IRepository<Ingredient>, Repository<Ingredient>>()
                .AddSingleton<IRepository<Product>, Repository<Product>>()
                .AddSingleton<IRepository<ProductIngredient>, Repository<ProductIngredient>>()
                .AddSingleton<IRepository<CategoryIngredient>, Repository<CategoryIngredient>>()
                .AddSingleton<IRepository<Review>, Repository<Review>>()
                .AddSingleton<IProductService, ProductService>()
                .BuildServiceProvider();

            var ingredientRepo = serviceProvider.GetService<IRepository<Ingredient>>();
            var categoryRepo = serviceProvider.GetService<IRepository<Category>>();
            var categoryIngredientRepo = serviceProvider.GetService<IRepository<CategoryIngredient>>();
            var productRepo = serviceProvider.GetService<IRepository<Product>>();
            var productIngredientRepo = serviceProvider.GetService<IRepository<ProductIngredient>>();

            await SeedDbAsync(ingredientRepo, categoryRepo, categoryIngredientRepo, productRepo, productIngredientRepo);
        }

        [Test]
        public async Task AllMustReturnAllProductsFromCurrentCategory()
        {
            var service = serviceProvider.GetService<IProductService>();
            var repo = serviceProvider.GetService<IRepository<Product>>();

            var products = await service.All(1);

            Assert.That(products.Count() > 0);
            Assert.That(repo.All().Any(p => p.Id == "0f0055eb-b982-440f-b7af-c43eb6bfab22"));
        }

        [Test]
        public void DetailsMustThrowOnUnknownProductId()
        {
            var service = serviceProvider.GetService<IProductService>();

            Assert.CatchAsync<ArgumentNullException>(async () => await service.Details("sadasd"), "Unknown product!");
        }

        [Test]
        public async Task DetailsMustReturnProductProperlyOnKnownProductId()
        {
            var service = serviceProvider.GetService<IProductService>();

            var product = await service.Details("0f0055eb-b982-440f-b7af-c43eb6bfab22");

            Assert.AreEqual("0f0055eb-b982-440f-b7af-c43eb6bfab22", product.Id);
            Assert.AreEqual("MyTestProduct", product.Name);
            Assert.AreEqual(300, product.WeightInGrams);
            Assert.AreEqual(1, product.CategoryId);
            Assert.AreEqual(4.50M, product.Price);
        }

        [Test]
        public async Task CategoryExistsMustReturnTrueIfCategoryExists()
        {
            var service = serviceProvider.GetService<IProductService>();

            var categoryExits = await service.CategoryExists(1);

            Assert.AreEqual(true, categoryExits);
        }

        [Test]
        public async Task CategoryExistsMustReturnFalseIfCategoryExists()
        {
            var service = serviceProvider.GetService<IProductService>();

            var categoryExits = await service.CategoryExists(-12321);

            Assert.AreEqual(false, categoryExits);
        }


        [Test]
        public async Task CreateAsyncMustCreateProduct()
        {
            var service = serviceProvider.GetService<IProductService>();
            var repo = serviceProvider.GetService<IRepository<Product>>();

            var productViewModel = new CreateProductViewModel()
            {
                Name = "CreatedIngredient",
                WeightInGrams = 300,
                Price = 5,
                CategoryId = 1,
                IngredientIds = new[] { "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778" },
                Image = "Image"
            };


            await service.CreateAsync(productViewModel);

            Assert.That(repo.All().Any(p => p.Name == productViewModel.Name));
        }

        [Test]
        public async Task CreateAsyncMustCreateSetProductPropertiesAndIngredientsProperyly()
        {
            var service = serviceProvider.GetService<IProductService>();
            var repo = serviceProvider.GetService<IRepository<Product>>();

            var productViewModel = new CreateProductViewModel()
            {
                Name = "CreatedIngredient",
                WeightInGrams = 300,
                Price = 5,
                CategoryId = 1,
                IngredientIds = new[] { "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778" },
                Image = "Image"
            };


            await service.CreateAsync(productViewModel);

            var createdProduct = repo.All().First(p => p.Name == productViewModel.Name);

            Assert.That(createdProduct.ProductsIngredients.Any(pi => pi.IngredientId == "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778"));
            Assert.AreEqual("CreatedIngredient", createdProduct.Name);
            Assert.AreEqual(productViewModel.WeightInGrams, createdProduct.WeightInGrams);
            Assert.AreEqual(productViewModel.CategoryId, createdProduct.CategoryId);
            Assert.AreEqual(productViewModel.Price, createdProduct.Price);
        }

        [Test]
        public void DeleteMustThrowWhenProductIdIsUnknown()
        {
            var service = serviceProvider.GetService<IProductService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.Delete("sadasd"), "Unknown product!");
        }

        [Test]
        public async Task DeleteMustDeleteProductWhenIdIsKnown()
        {
            var service = serviceProvider.GetService<IProductService>();
            var repo = serviceProvider.GetService<IRepository<Product>>();

            await service.Delete("0f0055eb-b982-440f-b7af-c43eb6bfab22");

            Assert.That(repo.All().Any(p => p.Id == "0f0055eb-b982-440f-b7af-c43eb6bfab22") == false);
        }

        [Test]
        public void EditAsyncMustThrowOnUnknownIngredient()
        {
            var service = serviceProvider.GetService<IProductService>();

            var editIngredientViewModel = new EditProductViewModel()
            {
                Id = "sadassad",
                Name = "EditIngredient",
                Price = 5,
                CategoryId = 1,
                WeightInGrams = 300,
                Image = "Image",
                IngredientIds = new[] { "0c6bc544-e4b4-4c1c-a9a8-acbbd6bbc88c" }
            };

            Assert.CatchAsync<ArgumentException>(async () => await service.EditAsync(editIngredientViewModel), "Unknown product!");
        }

        [Test]
        public async Task EditAsyncMustEditProduct()
        {
            var repo = serviceProvider.GetService<IRepository<Product>>();
            var service = serviceProvider.GetService<IProductService>();

            var editProductViewModel = new EditProductViewModel()
            {
                Id = "0f0055eb-b982-440f-b7af-c43eb6bfab22",
                Name = "EditIngredient",
                Price = 5,
                CategoryId = 1,
                WeightInGrams = 300,
                Image = "Image",
                IngredientIds = new[] { "0c6bc544-e4b4-4c1c-a9a8-acbbd6bbc88c" }
            };

            await service.EditAsync(editProductViewModel);

            var editedProduct = repo.All().FirstOrDefault(i => i.Id == "0f0055eb-b982-440f-b7af-c43eb6bfab22");

            Assert.AreEqual(editProductViewModel.Name, editedProduct.Name);
        }

        [Test]
        public async Task EditAsyncMustSetProductPropertiesAndIngredientsProperly()
        {
            var service = serviceProvider.GetService<IProductService>();
            var repo = serviceProvider.GetService<IRepository<Product>>();

            var editProductViewModel = new EditProductViewModel()
            {
                Id = "0f0055eb-b982-440f-b7af-c43eb6bfab22",
                Name = "EditIngredient",
                Price = 5,
                CategoryId = 1,
                WeightInGrams = 300,
                Image = "Image",
                IngredientIds = new[] { "0c6bc544-e4b4-4c1c-a9a8-acbbd6bbc88c" }
            };

            await service.EditAsync(editProductViewModel);

            var editedProduct = repo.All().FirstOrDefault(i => i.Id == "0f0055eb-b982-440f-b7af-c43eb6bfab22");

            Assert.That(editedProduct.ProductsIngredients.Any(pi => pi.IngredientId == "0c6bc544-e4b4-4c1c-a9a8-acbbd6bbc88c"));
            Assert.That(editedProduct.ProductsIngredients.Any(pi => pi.IngredientId == "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778") == false);

        }

        [Test]
        public void FindByIdMustThrowOnUnknownId()
        {
            var service = serviceProvider.GetService<IProductService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.FindById("sadas"), "Unknown product!");
        }

        [Test]
        public async Task FindByIdMustReturnRightProduct()
        {
            var service = serviceProvider.GetService<IProductService>();

            var product = await service.FindById("0f0055eb-b982-440f-b7af-c43eb6bfab22");

            Assert.AreEqual("MyTestProduct", product.Name);
            Assert.AreEqual(4.50M, product.Price);
            Assert.AreEqual(300, product.WeightInGrams);
            Assert.AreEqual(1, product.CategoryId);
            Assert.AreEqual("https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg", product.Image);
        }

        [Test]
        public async Task LoadCategoriesMustReturnAllAvailableCategories()
        {
            var service = serviceProvider.GetService<IProductService>();

            var productCategoryViewModels = await service.LoadCategories();

            Assert.That(productCategoryViewModels.Count() > 0);
        }

        [Test]
        public async Task LoadIngredientsMustLoadIngredientsForGivenCategoryId()
        {
            var service = serviceProvider.GetService<IProductService>();
            var categoryIngredientRepo = serviceProvider.GetService<IRepository<CategoryIngredient>>();

            var productIngredientViewModels = await service.LoadIngredients(1);

            Assert.That(productIngredientViewModels.Count() > 0);

            foreach (var productIngredientViewModel in productIngredientViewModels)
            {
                Assert.That(categoryIngredientRepo.All().Any(ci => ci.CategoryId == 1 && ci.IngredientId == productIngredientViewModel.IngredientId));
            }
        }

        [Test]
        public async Task LoadIngredientsWithSecondParameterMustLoadIngredientsForGivenCategoryIdAndShowSelectedIngredients()
        {
            var service = serviceProvider.GetService<IProductService>();
            var categoryIngredientRepo = serviceProvider.GetService<IRepository<CategoryIngredient>>();

            var productIngredientViewModels = await service.LoadIngredients(1, "0f0055eb-b982-440f-b7af-c43eb6bfab22");

            Assert.That(productIngredientViewModels.Count() > 0);
            Assert.That(productIngredientViewModels.First(i => i.IngredientId == "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778").IsSelected == true);
            foreach (var productIngredientViewModel in productIngredientViewModels)
            {
                Assert.That(categoryIngredientRepo.All().Any(ci => ci.CategoryId == 1 && ci.IngredientId == productIngredientViewModel.IngredientId));
            }
        }

        [Test]
        public async Task UncategorizedProductsMustReturnProductsWithoutCategory()
        {
            var service = serviceProvider.GetService<IProductService>();
            var productRepo = serviceProvider.GetService<IRepository<Product>>();

            var uncategorizedProducts = await service.UncategorizedProducts();

            Assert.That(uncategorizedProducts.Count() > 0);

            foreach (var uncategorizedProduct in uncategorizedProducts)
            {
                Assert.That(productRepo.All().First(p => p.Id == uncategorizedProduct.Id).Category == null);
            }
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository<Ingredient> ingredientRepo,
            IRepository<Category> categoryRepo,
            IRepository<CategoryIngredient> categoryIngredientRepo,
            IRepository<Product> productRepo,
            IRepository<ProductIngredient> productIngredientRepo)
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

            var uncategorizedProduct = new Product()
            {
                Id = "039262bb-6ffe-4eb3-8867-95a35ad022e9",
                Name = "UncategorizedProduct",
                CategoryId = null,
                Price = 4,
                Image = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg",
                WeightInGrams = 400,
            };

            if (productRepo.All().Any(p => p.Id == uncategorizedProduct.Id) == false)
            {
                await productRepo.AddAsync(uncategorizedProduct);
                await productRepo.SaveChangesAsync();
            }

            var productIngredient = new ProductIngredient()
            {
                ProductId = "0f0055eb-b982-440f-b7af-c43eb6bfab22",
                IngredientId = "64b1ab46-d9e5-4cb0-bb3b-cce5ecf2e778"
            };

            if (productIngredientRepo.All().Any(pi => pi.ProductId == productIngredient.ProductId && pi.IngredientId == productIngredient.IngredientId) == false)
            {
                await productIngredientRepo.AddAsync(productIngredient);
                await productIngredientRepo.SaveChangesAsync();
            }
        }
    }
}
