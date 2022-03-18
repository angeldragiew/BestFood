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
        private readonly IRepository<Category> categoryRepo;
        private readonly IRepository<CategoryIngredient> categoryIngredientRepo;

        public IngredientService(IRepository<Ingredient> repo,
            IRepository<Category> categoryRepo,
            IRepository<CategoryIngredient> categoryIngredientRepo)
        {
            this.repo = repo;
            this.categoryRepo = categoryRepo;
            this.categoryIngredientRepo = categoryIngredientRepo;
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
                     CategoryNames = c.CategoryIngredients.Select(c => c.Category.Name).ToList()
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

        public async Task Delete(string id)
        {
            Ingredient ingredient = await repo
                .All()
                .FirstOrDefaultAsync(i => i.Id == id);

            if (ingredient == null)
            {
                throw new ArgumentException("Unknown ingredient!");
            }

            repo.Delete(ingredient);
            await repo.SaveChangesAsync();
        }

        public async Task EditAsync(EditIngredientViewModel model)
        {
            Ingredient ingredient = await repo.All().FirstOrDefaultAsync(e => e.Id == model.Id);

            if (ingredient == null)
            {
                throw new AggregateException("Unknown ingredient!");
            }

            ingredient.Name = model.Name;
            ingredient.Type = model.Type;

            categoryIngredientRepo.DeleteRange(categoryIngredientRepo
                                                .All()
                                                .Where(c=> c.IngredientId == model.Id));

            foreach (var id in model.CategoryIds)
            {
                ingredient.CategoryIngredients.Add(new CategoryIngredient()
                {
                    Ingredient = ingredient,
                    CategoryId = id
                });
            }

            await repo.SaveChangesAsync();
        }

        public async Task<EditIngredientViewModel> FindById(string id)
        {
            EditIngredientViewModel ingredient = await repo.All().Select(e => new EditIngredientViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Type = e.Type,
                CategoryIds = e.CategoryIngredients.Select(c => c.CategoryId).ToArray()
            }).FirstOrDefaultAsync(e => e.Id == id);

            if (ingredient == null)
            {
                throw new ArgumentException("Unknown ingredient!");
            }

            return ingredient;
        }

        public async Task<IEnumerable<IngredientCategoryViewModel>> LoadCategoriesForCreate()
        {
            return await categoryRepo
                .All()
                .Select(c => new IngredientCategoryViewModel()
                {
                    CategoryId = c.Id,
                    IsSelected = false,
                    CategoryName = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<IngredientCategoryViewModel>> LoadCategoriesForEdit(string id)
        {
            return await categoryRepo
                .All()
                .Select(c => new IngredientCategoryViewModel()
                {
                    CategoryId = c.Id,
                    IsSelected = c.CategoriesIngredients.Contains(new CategoryIngredient()
                    {
                        CategoryId = c.Id,
                        IngredientId = id
                    }),
                    CategoryName = c.Name,
                })
                .ToListAsync();
        }

        public void SaveSubmittedCategoryValues(IEnumerable<IngredientCategoryViewModel> categories, IList<int> categoryIds)
        {
            foreach (var cat in categories)
            {
                if (categoryIds.Contains(cat.CategoryId))
                {
                    cat.IsSelected = true;
                }
                else
                {
                    cat.IsSelected = false;
                }
            }
        }
    }
}
