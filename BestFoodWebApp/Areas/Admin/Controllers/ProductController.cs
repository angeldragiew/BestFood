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
            if (await productService.CategoryExists(model.CategoryId) == false)
            {
                ModelState.AddModelError("CategoryId", "Invalid Category!");
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid data!";
                ViewBag.Categories = await productService.LoadCategoriesForCreate();
                return View(model);
            }

            try
            {
                await productService.CreateAsync(model);
                TempData[MessageConstant.SuccessMessage] = "Product created successfully!";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not create product!";
            }
            return RedirectToAction("All", "Category", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                EditProductViewModel model = await productService.FindById(id);
                ViewBag.Categories = await productService.LoadCategoriesForCreate();
                return View(model);
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("All", "Category", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (await productService.CategoryExists(model.CategoryId) == false)
            {
                ModelState.AddModelError("CategoryId", "Invalid Category!");
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid data!";
                ViewBag.Categories = await productService.LoadCategoriesForCreate();
                return View(model);
            }

            try
            {
                await productService.EditAsync(model);
                TempData[MessageConstant.SuccessMessage] = "Product editted successfully!";
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }

            return RedirectToAction("All", "Category", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await productService.Delete(id);
                TempData[MessageConstant.SuccessMessage] = "Product deleted successfully!";
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("All", "Category", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> LoadIngredients(int categoryId, string productId)
        {
            if (productId != null)
            {
                ViewBag.ProductIngredients = await productService.LoadIngredients(categoryId, productId);
            }
            else
            {
                ViewBag.ProductIngredients = await productService.LoadIngredients(categoryId);
            }


            return PartialView("_ProductIngredientsPartial");
        }
    }
}
