using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Category;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repo;

        public CategoryService(IRepository<Category> repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<CategoryViewModel>> All()
        {
            return await repo
                .All()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = c.Image
                }).ToListAsync();

        }

        public async Task CreateAsync(CreateCategoryViewModel model)
        {
            Category category = new Category()
            {
                Name = model.Name,
                Image = model.Image,
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Category category = await repo.All().FirstOrDefaultAsync(e => e.Id == id);

            if (category == null)
            {
                throw new ArgumentNullException("Unknown category!");
            }

            repo.Delete(category);
            await repo.SaveChangesAsync();
        }

        public async Task EditAsync(EditCategoryViewModel model)
        {
            Category category = await repo.All().FirstOrDefaultAsync(e => e.Id == model.Id);

            if (category == null)
            {
                throw new ArgumentNullException("Unknown category!");
            }

            category.Name = model.Name;
            category.Image = model.Image;

            await repo.SaveChangesAsync();
        }

        public async Task<EditCategoryViewModel> FindById(int id)
        {
            EditCategoryViewModel category = await repo.All().Select(e => new EditCategoryViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Image = e.Image
            }).FirstOrDefaultAsync(e => e.Id == id);

            if (category == null)
            {
                throw new ArgumentNullException("Unknown category!");
            }

            return category;
        }

        public async Task<string> GetCategoryNameById(int id)
        {
            var categoy =  await repo
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);
            if(categoy == null)
            {
                return null;
            }

            return categoy.Name;
        }
    }
}
