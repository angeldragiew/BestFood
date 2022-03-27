using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Product;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Category> categoryRepo;
        private readonly IRepository<Ingredient> ingredientRepo;

        public ProductService(IRepository<Category> categoryRepo,
            IRepository<Ingredient> ingredientRepo)
        {
            this.categoryRepo = categoryRepo;
            this.ingredientRepo = ingredientRepo;
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> LoadCategoriesForCreate()
        {
            return await categoryRepo
                .All()
                .Select(c => new ProductCategoryViewModel()
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    IsSelected = false
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id)
        {
            return await ingredientRepo
                .All()
                .Where(i => i.CategoryIngredients.Any(i => i.Category.Id == id))
                .Select(i => new ProductIngredientViewModel()
                {
                    IngredientId = i.Id,
                    IngredientName = i.Name,
                    IsSelected = false
                })
                .ToListAsync();
        }
    }
}
