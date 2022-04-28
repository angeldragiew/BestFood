using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Core.Services;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Order;
using BestFood.Infrastructure.Data;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using BestFood.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BestFood.Tests
{
    public class OrderServiceTests
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
                .AddSingleton<IRepository<CartItem>, Repository<CartItem>>()
                .AddSingleton<IRepository<Order>, Repository<Order>>()
                .AddSingleton<IRepository<ApplicationUser>, Repository<ApplicationUser>>()
                .AddSingleton<IRepository<Category>, Repository<Category>>()
                .AddSingleton<IRepository<Product>, Repository<Product>>()
                .AddSingleton<IRepository<Ingredient>, Repository<Ingredient>>()
                .AddSingleton<IRepository<CategoryIngredient>, Repository<CategoryIngredient>>()
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();

            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();
            var orderRepo = serviceProvider.GetService<IRepository<Order>>();
            var productRepo = serviceProvider.GetService<IRepository<Product>>();
            var categoryRepo = serviceProvider.GetService<IRepository<Category>>();
            var cartItemRepo = serviceProvider.GetService<IRepository<CartItem>>();
            var ingredientRepo = serviceProvider.GetService<IRepository<Ingredient>>();
            var categoryIngredientRepo = serviceProvider.GetService<IRepository<CategoryIngredient>>();

            await SeedDbAsync(userRepo, orderRepo, productRepo, categoryRepo, cartItemRepo, ingredientRepo, categoryIngredientRepo);
        }

        [Test]
        public void CreateAsyncMustThrowWhenCartIsEmpty()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var createOrderViewModel = new CreateOrderViewModel()
            {
                Address = "Iordan 8",
                PhoneNumber = "83821939100"
            };

            Assert.CatchAsync<ArgumentException>(async () => await service.CreateAsync("unknownCartsad", "angel@gmail.com", createOrderViewModel), "Cart is emtpy!");
        }

        [Test]
        public void CreateAsyncMustThrowWhenUnknownUser()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var createOrderViewModel = new CreateOrderViewModel()
            {
                Address = "Iordan 8",
                PhoneNumber = "83821939100"
            };

            Assert.CatchAsync<ArgumentException>(async () => await service.CreateAsync("angel", "unknownuserasd", createOrderViewModel), "Unknown user");
        }

        [Test]
        public async Task CreateAsyncMustCreateOrderWhenCartIsNotEmptyAndUsernameIsValid()
        {
            var service = serviceProvider.GetService<IOrderService>();
            var orderRepo = serviceProvider.GetService<IRepository<Order>>();

            var createOrderViewModel = new CreateOrderViewModel()
            {
                Address = "TestAddress",
                PhoneNumber = "00000000000"
            };

            await service.CreateAsync("angel", "angel@gmail.com", createOrderViewModel);

            Assert.That(orderRepo.All().Any(o => o.Amount == 4.50M));
            Assert.That(orderRepo.All().Any(o => o.Address == "TestAddress"));
            Assert.That(orderRepo.All().Any(o => o.PhoneNumber == "00000000000"));
            Assert.That(orderRepo.All().Any(o => o.ProductsInfo == $"1 MyTestProduct - {4.50M:f2} lv."));
        }

        [Test]
        public async Task AllMustReturnOrderListViewModelProperly()
        {
            var service = serviceProvider.GetService<IOrderService>();
            var orderRepo = serviceProvider.GetService<IRepository<Order>>();

            var orderListViewModel = await service.All(1, 5);

            Assert.That(orderListViewModel.PageNo == 1);
            Assert.That(orderListViewModel.PageSize == 5);
            Assert.That(orderListViewModel.TotalRecords > 0);
            Assert.That(orderListViewModel.Orders.Count() > 0);
            Assert.That(orderListViewModel.Orders.Any(o => o.Id == "da9f8d0f-c849-4b64-8239-d43df2fa25eb"));
        }

        [Test]
        public async Task AllMustReturnEmptyOrderCollectionWhenPageIsTooBig()
        {
            var service = serviceProvider.GetService<IOrderService>();
            var orderRepo = serviceProvider.GetService<IRepository<Order>>();

            var orderListViewModel = await service.All(2222, 5);

            Assert.That(orderListViewModel.PageNo == 2222);
            Assert.That(orderListViewModel.PageSize == 5);
            Assert.That(orderListViewModel.TotalRecords > 0);
            Assert.That(orderListViewModel.Orders.Count() == 0);
        }

        [Test]
        public async Task AllPendingOrdersMustReturnOrderListViewModelProperly()
        {
            var service = serviceProvider.GetService<IOrderService>();
            var orderRepo = serviceProvider.GetService<IRepository<Order>>();

            var orderListViewModel = await service.AllPendingOrders(1, 5);

            Assert.That(orderListViewModel.PageNo == 1);
            Assert.That(orderListViewModel.PageSize == 5);
            Assert.That(orderListViewModel.TotalRecords > 0);
            Assert.That(orderListViewModel.Orders.Count() > 0);
            Assert.That(orderListViewModel.Orders.Any(o => o.Id == "da9f8d0f-c849-4b64-8239-d43df2fa25eb"));
            Assert.That(orderListViewModel.Orders.Any(o => o.Id == "b3dbfd2d-c842-420f-93cf-661514a8ae6e") == false);

            foreach (var order in orderListViewModel.Orders)
            {
                Assert.That(order.OrderStatus == OrderStatus.Pending);
            }
        }

        [Test]
        public async Task AllPendingOrdersMustReturnEmptyOrderCollectionWhenPageIsTooBig()
        {
            var service = serviceProvider.GetService<IOrderService>();
            var orderRepo = serviceProvider.GetService<IRepository<Order>>();

            var orderListViewModel = await service.All(2222, 5);

            Assert.That(orderListViewModel.PageNo == 2222);
            Assert.That(orderListViewModel.PageSize == 5);
            Assert.That(orderListViewModel.TotalRecords > 0);
            Assert.That(orderListViewModel.Orders.Count() == 0);
        }

        [Test]
        public async Task AllUserOrdersMustReturnOnlyOrdersThatBelongToGivenUser()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var userOrders = await service.AllUserOrders("angel@gmail.com");

            Assert.That(userOrders.Count() == 2);
        }

        [Test]
        public void OrderDetailsMustThrownOnUnknownOrderId()
        {
            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.OrderDetails("sadas"), "Unknown order!");
        }

        [Test]
        public async Task OrderDetailsMustReturnOrderDetailViewModelWhenOrderIdISValid()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var order = new Order()
            {
                Id = "da9f8d0f-c849-4b64-8239-d43df2fa25eb",
                ApplicationUserId = "83a52d86-0f92-49b1-9bed-9910a722d4f5",
                PhoneNumber = "123456789",
                Address = "testAddress",
                ProductsInfo = $"1 MyTestProduct - {4.50M:f2} lv.",
                OrderStatus = OrderStatus.Pending,
                Amount = 4.50M,
                CreationDate = DateTime.Now,
                Note = "Some note from user"
            };

            var orderViewModel = await service.OrderDetails("da9f8d0f-c849-4b64-8239-d43df2fa25eb");

            Assert.That(orderViewModel.Id == order.Id);
            Assert.That(orderViewModel.Amount == order.Amount.ToString());
            Assert.That(orderViewModel.Note == order.Note);
            Assert.That(orderViewModel.Note == order.Note);
            Assert.That(orderViewModel.ProductsInfo == order.ProductsInfo);
            Assert.That(orderViewModel.Address == order.Address);
            Assert.That(orderViewModel.PhoneNumber == order.PhoneNumber);
        }

        [Test]
        public void AcceptOrderMustThrowOnUnknownOrderId()
        {
            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.AcceptOrder("sadas"), "Unknown order!");
        }

        [Test]
        public void AcceptOrderMustThrowIfOrderStatusIsNotPending()
        {
            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.AcceptOrder("b3dbfd2d-c842-420f-93cf-661514a8ae6e"), "Order has been already processed!");
        }


        [Test]
        public async Task AcceptOrderMustChangeOrderOderStatusToAccepted()
        {
            var service = serviceProvider.GetService<IOrderService>();
            var orderRepo = serviceProvider.GetService<IRepository<Order>>();

            await service.AcceptOrder("da9f8d0f-c849-4b64-8239-d43df2fa25eb");

            Assert.That(orderRepo.All().FirstOrDefault(o => o.Id == "da9f8d0f-c849-4b64-8239-d43df2fa25eb").OrderStatus == OrderStatus.Accepted);
        }

        [Test]
        public void RejectOrderMustThrowOnUnknownOrderId()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var rejectOrderViewModel = new RejectOrderViewModel()
            {
                RejectOrderId= "sadas",
                RejectOrderNote = "Order is rejected"
            };
            Assert.CatchAsync<ArgumentException>(async () => await service.RejectOrder(rejectOrderViewModel), "Unknown order!");
        }

        [Test]
        public void RejectOrderMustThrowIfOrderStatusIsNotPending()
        {
            var service = serviceProvider.GetService<IOrderService>();

            var rejectOrderViewModel = new RejectOrderViewModel()
            {
                RejectOrderId = "b3dbfd2d-c842-420f-93cf-661514a8ae6e",
                RejectOrderNote = "Order is rejected"
            };

            Assert.CatchAsync<ArgumentException>(async () => await service.RejectOrder(rejectOrderViewModel), "Order has been already processed!");
        }

        [Test]
        public async Task RejectOrderMustChangeOrderOderStatusToRejectedAndSetRejectionNoteProperly()
        {
            var service = serviceProvider.GetService<IOrderService>();
            var orderRepo = serviceProvider.GetService<IRepository<Order>>();


            var rejectOrderViewModel = new RejectOrderViewModel()
            {
                RejectOrderId = "da9f8d0f-c849-4b64-8239-d43df2fa25eb",
                RejectOrderNote = "Order is rejected"
            };
            await service.RejectOrder(rejectOrderViewModel);

            Assert.That(orderRepo.All().FirstOrDefault(o => o.Id == "da9f8d0f-c849-4b64-8239-d43df2fa25eb").OrderStatus == OrderStatus.Rejected);
            Assert.That(orderRepo.All().FirstOrDefault(o => o.Id == "da9f8d0f-c849-4b64-8239-d43df2fa25eb").Note == rejectOrderViewModel.RejectOrderNote);
            Assert.That(orderRepo.All().FirstOrDefault(o => o.Id == "da9f8d0f-c849-4b64-8239-d43df2fa25eb").Note != null);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository<ApplicationUser> userRepo,
            IRepository<Order> orderRepo,
            IRepository<Product> productRepo,
            IRepository<Category> categoryRepo,
            IRepository<CartItem> cartItemRepo,
            IRepository<Ingredient> ingredientRepo,
            IRepository<CategoryIngredient> categoryIngredientRepo)
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


            var order = new Order()
            {
                Id = "da9f8d0f-c849-4b64-8239-d43df2fa25eb",
                ApplicationUserId = "83a52d86-0f92-49b1-9bed-9910a722d4f5",
                PhoneNumber = "123456789",
                Address = "testAddress",
                ProductsInfo = $"1 MyTestProduct - {4.50M:f2} lv.",
                OrderStatus = OrderStatus.Pending,
                Amount = 4.50M,
                CreationDate = DateTime.Now,
                Note = "Some note from user"
            };

            if (orderRepo.All().Any(o => o.Id == order.Id) == false)
            {
                await orderRepo.AddAsync(order);
                await orderRepo.SaveChangesAsync();
            }

            var orderTwo = new Order()
            {
                Id = "b3dbfd2d-c842-420f-93cf-661514a8ae6e",
                ApplicationUserId = "83a52d86-0f92-49b1-9bed-9910a722d4f5",
                PhoneNumber = "9876543210",
                Address = "testAddress2",
                ProductsInfo = $"1 MyTestProduct - {4.50M:f2} lv.",
                OrderStatus = OrderStatus.Accepted,
                Amount = 4.50M,
                CreationDate = DateTime.Now,
                Note = "Some note from user"
            };

            if (orderRepo.All().Any(o => o.Id == orderTwo.Id) == false)
            {
                await orderRepo.AddAsync(orderTwo);
                await orderRepo.SaveChangesAsync();
            }
        }
    }
}
