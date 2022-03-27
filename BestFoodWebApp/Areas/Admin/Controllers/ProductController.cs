using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await productService.LoadCategoriesForCreate();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid data!";
                return View(model);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadIngredients(int id)
        {
            var ingredients = await productService.LoadIngredients(id);

            return PartialView("_ProductIngredientsPartial", ingredients);
        }
    }
}
