using BestFood.Core.Constants;
using BestFood.Core.Services;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allCategories = await categoryService.All();
            return View(allCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                TempData[MessageConstant.ErrorMessage] = messages;
                return View(model);
            }

            try
            {
                await categoryService.CreateAsync(model);
                return RedirectToAction("All", "Category");
            }
            catch(Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not create the category!";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await categoryService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("All", "Category");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                EditCategoryViewModel model = await categoryService.FindById(id);
                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("All", "Category");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                TempData[MessageConstant.ErrorMessage] = messages;
                return View(model);
            }

            try
            {
                await categoryService.EditAsync(model);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }

            return RedirectToAction("All", "Category");
        }
    }
}
