using BestFood.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        public const string CartSessionKey = "CartId";
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> AddToCart(string id)
        {
            if (HttpContext.Session.GetString(CartSessionKey) == null)
            {
                HttpContext.Session.SetString(CartSessionKey, User.Identity.Name);
            }
            await shoppingCartService.AddItemToCartAsync(HttpContext.Session.GetString(CartSessionKey), id);

            return RedirectToAction("MyCart", "ShoppingCart");
        }

        public async Task<IActionResult> ClearCart()
        {
            if (HttpContext.Session.GetString(CartSessionKey) == null)
            {
                HttpContext.Session.SetString(CartSessionKey, User.Identity.Name);
            }
            await shoppingCartService.ClearCart(HttpContext.Session.GetString(CartSessionKey));

            return PartialView("_ShoppingCartItemsPartial", null);
        }

        public async Task<IActionResult> MyCart()
        {
            if (HttpContext.Session.GetString(CartSessionKey) == null)
            {
                HttpContext.Session.SetString(CartSessionKey, User.Identity.Name);
            }
            ViewBag.CartItems = await shoppingCartService.AllAsync(HttpContext.Session.GetString(CartSessionKey));

            return View();
        }

        public async Task<IActionResult> IncreaseQuantity(string id)
        {
            await shoppingCartService.IncreaseQuantityAsync(id, HttpContext.Session.GetString(CartSessionKey));

            ViewBag.CartItems = await shoppingCartService.AllAsync(HttpContext.Session.GetString(CartSessionKey));

            return PartialView("_ShoppingCartItemsPartial");
        }

        public async Task<IActionResult> DecreaseQuantity(string id)
        {
            await shoppingCartService.DecreaseQuantityAsync(id, HttpContext.Session.GetString(CartSessionKey));
            ViewBag.CartItems = await shoppingCartService.AllAsync(HttpContext.Session.GetString(CartSessionKey));

            return PartialView("_ShoppingCartItemsPartial");
        }


    }
}
