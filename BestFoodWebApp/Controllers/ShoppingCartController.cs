using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        public const string CartSessionKey = "CartId";
        private readonly IShoppingCartService shoppingCartService;
        private readonly IUserService userService;

        public ShoppingCartController(IShoppingCartService shoppingCartService,
            IUserService userService)
        {
            this.shoppingCartService = shoppingCartService;
            this.userService = userService;
        }

        public async Task<IActionResult> AddToCart(string id)
        {
            if (HttpContext.Session.GetString(CartSessionKey) == null)
            {
                HttpContext.Session.SetString(CartSessionKey, User.Identity.Name);
            }
            try
            {
                await shoppingCartService.AddItemToCartAsync(HttpContext.Session.GetString(CartSessionKey), id);
            }
            catch (Exception ex)
            {
                TempData[MessageConstant.ErrorMessage] = "Product was not added to cart! " + ex.Message;
            }

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

            var addressAndPhone = await userService.GetUserAddressAndPhoneNUmber(User.Identity.Name);

            ViewBag.Address = addressAndPhone.Address;
            ViewBag.PhoneNumber = addressAndPhone.PhoneNumber;

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
