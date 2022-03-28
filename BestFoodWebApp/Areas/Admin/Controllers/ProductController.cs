﻿using BestFood.Core.Constants;
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
            if(await productService.CategoryExists(model.CategoryId) == false)
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
                TempData[MessageConstant.SuccessMessage] = "Ingredient created successfully!";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not create ingredient!";
            }
            return RedirectToAction("All", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> LoadIngredients(int id)
        {
            ViewBag.ProductIngredients = await productService.LoadIngredients(id);

            return PartialView("_ProductIngredientsPartial");
        }
    }
}
