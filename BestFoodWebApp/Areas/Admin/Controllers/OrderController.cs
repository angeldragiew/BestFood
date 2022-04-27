using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Order;
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
        public async Task<IActionResult> PendingOrders(int p = 1, int s = 10)
        {
            var pendingOrders = await orderService.AllPendingOrders(p, s);
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
        public async Task<IActionResult> All(int p = 1, int s = 10)
        {
            var orders = await orderService.All(p, s);
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

        [HttpPost]
        public async Task<IActionResult> RejectOrder(RejectOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = String.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return RedirectToAction("Details", "Order", new { id = model.RejectOrderId });
            }

            try
            {
                await orderService.RejectOrder(model);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("PendingOrders", "Order");
        }
    }
}
