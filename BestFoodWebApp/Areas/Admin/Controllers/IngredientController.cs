using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Areas.Admin.Controllers
{
    public class IngredientController : BaseController
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
                TempData[MessageConstant.ErrorMessage] = "Invalid data!";

                var categories = await ingredientService.LoadCategoriesForCreate();
                ingredientService.SaveSubmittedCategoryValues(categories, model.CategoryIds);
                ViewBag.Categories = categories;
                return View(model);
            }

            try
            {
                await ingredientService.CreateAsync(model);
                TempData[MessageConstant.SuccessMessage] = "Ingredient created successfully!";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not create ingredient!";
            }
            return RedirectToAction("All", "Ingredient");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await ingredientService.Delete(id);
                TempData[MessageConstant.SuccessMessage] = "Ingredient deleted successfully!";

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
                TempData[MessageConstant.ErrorMessage] = "Invalid data!";
                var categories = await ingredientService.LoadCategoriesForEdit(model.Id);
                ingredientService.SaveSubmittedCategoryValues(categories, model.CategoryIds);
                ViewBag.Categories = categories;
                return View(model);
            }

            try
            {
                await ingredientService.EditAsync(model);
                TempData[MessageConstant.SuccessMessage] = "Ingredient editted successfully!";
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("All", "Ingredient");
        }
    }
}
