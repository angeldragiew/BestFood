using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService,
            ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService=categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
            ViewBag.CategoryName = await categoryService.GetCategoryNameById(id);
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
    }
}
