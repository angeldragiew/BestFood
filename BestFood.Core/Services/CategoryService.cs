using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Category;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;

namespace BestFood.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IEnumerable<CreateCategoryViewModel> All()
        {
            return categoryRepo
                .All()
                .Select(c => new CreateCategoryViewModel()
                {
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

            await categoryRepo.AddAsync(category);
            await categoryRepo.SaveChangesAsync();
        }
    }
}
