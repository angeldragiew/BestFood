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

        [HttpPost]
        public async Task<IActionResult> RejectOrder(RejectOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid Data!";
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
