using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Ingredient;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestFoodWebApp.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allIngredients = await ingredientService.All();
            return View(allIngredients);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await ingredientService.LoadCategoriesForCreate();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIngredientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                TempData[MessageConstant.ErrorMessage] = messages;
                //ViewBag.Categories = await ingredientService.LoadCategoriesForCreate();

                var categories = await ingredientService.LoadCategoriesForCreate();
                ingredientService.SaveSubmittedCategoryValues(categories, model.CategoryIds);
                ViewBag.Categories = categories;
                return View(model);
            }

            try
            {
                await ingredientService.CreateAsync(model);
                return RedirectToAction("All", "Ingredient");
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not create the category!";
                return RedirectToAction("Create", "Ingredient");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await ingredientService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("All", "Ingredient");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Categories = await ingredientService.LoadCategoriesForEdit(id);

            try
            {
                EditIngredientViewModel model = await ingredientService.FindById(id);
                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("All", "Ingredient");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditIngredientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                TempData[MessageConstant.ErrorMessage] = messages;
                var categories = await ingredientService.LoadCategoriesForEdit(model.Id);
                ingredientService.SaveSubmittedCategoryValues(categories, model.CategoryIds);
                ViewBag.Categories = categories;
                return View(model);
            }

            try
            {
                await ingredientService.EditAsync(model);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("All", "Ingredient");
        }
    }
}
