using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Ingredient;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepository<Ingredient> repo;

        public IngredientService(IRepository<Ingredient> repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<IngredientViewModel>> All()
        {
            return await repo
                 .All()
                 .Select(c => new IngredientViewModel()
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Type = c.Type,
                     CategoryIngredients =c.CategoryIngredients
                 }).ToListAsync();
        }

        public async Task CreateAsync(CreateIngredientViewModel model)
        {
            Ingredient ingredient = new Ingredient()
            {
                Name = model.Name,
                Type = model.Type,
            };

            foreach (var id in model.CategoryIds)
            {
                ingredient.CategoryIngredients.Add(new CategoryIngredient()
                {
                    Ingredient = ingredient,
                    CategoryId = id
                });
            }

            await repo.AddAsync(ingredient);
            await repo.SaveChangesAsync();
        }
    }
}
