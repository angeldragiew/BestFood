using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> PendingOrders()
        {
            var pendingOrders = await orderService.AllPendingOrders();
            return View(pendingOrders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var order = await orderService.OrderDetails(id);
                return View(order);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("PendingOrders", "Order");
            }
        }
    }
}
