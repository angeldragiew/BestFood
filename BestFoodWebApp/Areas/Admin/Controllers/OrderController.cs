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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var orders = await orderService.All();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> AcceptOrder(string id)
        {
            try
            {
                await orderService.AcceptOrder(id);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("PendingOrders", "Order");
        }

        [HttpGet]
        public async Task<IActionResult> RejectOrder(string id)
        {
            try
            {
                await orderService.RejectOrder(id);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("PendingOrders", "Order");
        }
    }
}
