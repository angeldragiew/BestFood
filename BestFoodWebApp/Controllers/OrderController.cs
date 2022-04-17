using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public const string CartSessionKey = "CartId";
        private readonly IOrderService orderService;
        private readonly IShoppingCartService cartService;

        public OrderController(IOrderService orderService,
            IShoppingCartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            if (HttpContext.Session.GetString(CartSessionKey) == null)
            {
                HttpContext.Session.SetString(CartSessionKey, User.Identity.Name);
            }

            var currentUserName = User.Identity.Name;

            try
            {
                await orderService.CreateAsync(HttpContext.Session.GetString(CartSessionKey), currentUserName, model);
                await cartService.ClearCart(HttpContext.Session.GetString(CartSessionKey));
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("MyCart", "ShoppingCart");
            }

            return RedirectToAction("MyOrders", "Order");
        }

        public async Task<IActionResult> MyOrders()
        {
            string name = User.Identity.Name;
            var myOrders = await orderService.AllUserOrders(User.Identity.Name);
            return View(myOrders);
        }
    }
}
