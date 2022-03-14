using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Category;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;

namespace BestFood.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            this.repo = categoryRepo;
        }

        public IEnumerable<CategoryViewModel> All()
        {
            return repo
                .All()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = c.Image
                }).ToList();

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

        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;

            Category category = repo.All().FirstOrDefault(e => e.Id == id);

            if (category != null)
            {
                repo.Delete(category);
                await repo.SaveChangesAsync();
                isDeleted = true;
            }
            return isDeleted;
        }

		public async Task EditAsync(CategoryViewModel model)
		{
            Category category = repo.All().FirstOrDefault(e => e.Id == model.Id);

            category.Name=model.Name;
            category.Image = model.Image;

            await repo.SaveChangesAsync();
        }

		public CategoryViewModel FindById(int id)
		{
            return repo.All().Select(e=> new CategoryViewModel()
			{
                Id=e.Id,
                Name =e.Name,
                Image=e.Image
			}).FirstOrDefault(e=>e.Id == id);
		}
	}
}
