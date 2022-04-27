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

        public async Task<OrderListViewModel> All(int pageNo, int pageSize)
        {
            OrderListViewModel result = new OrderListViewModel()
            {
                PageNo = pageNo,
                PageSize = pageSize
            };

            result.TotalRecords = await orderRepository.All().CountAsync();

            result.Orders = await orderRepository
                .All()
                .OrderByDescending(o => o.CreationDate)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Address = o.Address,
                    CreationDate = o.CreationDate.ToString("dd.MM.yyyy HH:mm"),
                    OrderStatus = o.OrderStatus,
                    PhoneNumber = o.PhoneNumber
                })
                .Skip(pageNo * pageSize - pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<OrderListViewModel> AllPendingOrders(int pageNo, int pageSize)
        {
            OrderListViewModel result = new OrderListViewModel()
            {
                PageNo = pageNo,
                PageSize = pageSize
            };

            result.TotalRecords = await orderRepository
                .All()
                .Where(o => o.OrderStatus == OrderStatus.Pending)
                .CountAsync();

            result.Orders = await orderRepository
                .All()
                .OrderByDescending(o => o.CreationDate)
                .Where(o => o.OrderStatus == OrderStatus.Pending)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Address = o.Address,
                    CreationDate = o.CreationDate.ToString("dd.MM.yyyy HH: mm"),
                    OrderStatus = o.OrderStatus,
                    PhoneNumber = o.PhoneNumber
                })
                .Skip(pageNo * pageSize - pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<OrderDetailViewModel>> AllUserOrders(string userName)
        {
            return await orderRepository
                .All()
                .Where(o => o.ApplicationUser.UserName == userName)
                .OrderByDescending(o => o.CreationDate)
                .Select(o => new OrderDetailViewModel()
                {
                    Id = o.Id,
                    Address = o.Address,
                    CreationDate = o.CreationDate.ToString("dd.MM.yyyy HH:mm"),
                    Amount = o.Amount.ToString("f2"),
                    Note = o.Note,
                    OrderStatus = o.OrderStatus,
                    ProductsInfo = o.ProductsInfo,
                    PhoneNumber = o.PhoneNumber
                }).ToListAsync();
        }

        public async Task CreateAsync(string shoppingCartId, string currentUserName, CreateOrderViewModel model)
        {
            var cartItems = await cartItemRepository
                .All()
                .Include(ci => ci.Product)
                .Where(c => c.CartId == shoppingCartId)
                .ToListAsync();

            if (cartItems == null || cartItems.Count == 0)
            {
                throw new ArgumentException("Cart is emtpy!");
            }

            var user = userRepository.All()
                .SingleOrDefault(u => u.UserName == currentUserName);

            if (user == null)
            {
                throw new ArgumentException("Unknown user");
            }


            Order order = new Order()
            {
                Address = model.Address,
                Note = model.Note,
                OrderStatus = OrderStatus.Pending,
                Amount = cartItems.Sum(ci => ci.Product.Price * ci.Quantity),
                ProductsInfo = string.Join(", ", cartItems
                                .Select(ci => $"{ci.Quantity} {ci.Product.Name} - {ci.Product.Price * ci.Quantity:f2} lv.")),
                ApplicationUser = user,
                PhoneNumber = model.PhoneNumber
            };

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();
        }

        public async Task<OrderDetailViewModel> OrderDetails(string id)
        {
            var order = await orderRepository
                .All()
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new ArgumentException("Unknown order!");
            }
            OrderDetailViewModel orderDetails = new OrderDetailViewModel()
            {
                Id = order.Id,
                Address = order.Address,
                CreationDate = order.CreationDate.ToString("d"),
                Amount = order.Amount.ToString("f2"),
                Note = order.Note,
                OrderStatus = order.OrderStatus,
                ProductsInfo = order.ProductsInfo,
                PhoneNumber = order.PhoneNumber
            };
            return orderDetails;
        }

        public async Task AcceptOrder(string id)
        {
            Order order = orderRepository
                .All()
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                throw new ArgumentException("Unknown order");
            }

            order.OrderStatus = OrderStatus.Accepted;
            await orderRepository.SaveChangesAsync();
        }

        public async Task RejectOrder(RejectOrderViewModel model)
        {
            Order order = orderRepository
                .All()
                .FirstOrDefault(o => o.Id == model.RejectOrderId);

            if (order == null)
            {
                throw new ArgumentException("Unknown order");
            }

            order.OrderStatus = OrderStatus.Rejected;
            if (!String.IsNullOrEmpty(model.RejectOrderNote))
            {
                order.Note = $"{model.RejectOrderNote}";
            }

            await orderRepository.SaveChangesAsync();
        }
    }
}
