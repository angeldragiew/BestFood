using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
            var products = await productService.All(id);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var product = await productService.Details(id);
                return View(product);
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("All", "Category");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RateProduct(CreateReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid data!";
                return RedirectToAction("Details", "Product", new { id = model.ProductId });
            }

            try
            {
                await productService.RateProdcutAsync(model, User.Identity.Name);
                TempData[MessageConstant.SuccessMessage] = "Review added successfully!";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not add the review!";
            }
            return RedirectToAction("Details", "Product", new { id = model.ProductId });
        }
    }
}
