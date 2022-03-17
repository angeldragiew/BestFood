using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Ingredient;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IRepository<Category> repo;
        private readonly IIngredientService ingredientService;

        public IngredientController(IRepository<Category> repo, IIngredientService ingredientService)
        {
            this.repo = repo;
            this.ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allIngredients = await ingredientService.All();
            return View(allIngredients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = repo
                .All()
                .Select(c => new CategoryCheckBoxViewModel
                {
                    CategoryId = c.Id,
                    IsSelected = false,
                    CategoryName = c.Name,
                })
                .ToList();

            ViewBag.Categories = categories;
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
                return RedirectToAction("Create", "Ingredient");
            }

            try
            {
                await ingredientService.CreateAsync(model);
                return RedirectToAction("Create", "Ingredient");
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not create the category!";
                return RedirectToAction("Create", "Ingredient");
            }
        }
    }
}
