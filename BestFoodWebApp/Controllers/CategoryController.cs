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
        public IActionResult All()
        {
            List<CreateCategoryViewModel> allCategories = categoryService.All().ToList();
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
                ViewData[MessageConstant.ErrorMessage] = messages;
                return View();
            }

            await categoryService.CreateAsync(model);

            return Redirect("/Category/All");
        }
    }
}
