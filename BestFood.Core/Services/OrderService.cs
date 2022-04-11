using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Order;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using BestFood.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<ApplicationUser> userRepository;

        public OrderService(IRepository<CartItem> cartItemRepository,
            IRepository<ApplicationUser> userRepository,
            IRepository<Order> orderRepository)
        {
            this.cartItemRepository = cartItemRepository;
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
        }

        public async Task CreateAsync(string shoppingCartId, string currentUserName, CreateOrderViewModel model)
        {
            var cartItems = await cartItemRepository
                .All()
                .Include(ci=>ci.Product)
                .Where(c => c.CartId == shoppingCartId)
                .ToListAsync();

            if (cartItems == null || cartItems.Count == 0)
            {
                throw new ArgumentException("Cart is emtpy!");
            }

            var user = userRepository.All()
                .SingleOrDefault(u=>u.UserName== currentUserName);

            if (user == null)
            {
                throw new ArgumentException("Unknown user");
            }


            Order order = new Order()
            {
                Address = model.Address,
                Note=model.Note,
                OrderStatus = OrderStatus.Pending,
                Amount = cartItems.Sum(ci=>ci.Product.Price*ci.Quantity),
                ProductsInfo=string.Join(Environment.NewLine, cartItems
                                .Select(ci=>$"{ci.Quantity} x {ci.Product.Name} - {ci.Product.Price*ci.Quantity:f2} lv.")),
                ApplicationUser = user
            };

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();
        }

    }
}
