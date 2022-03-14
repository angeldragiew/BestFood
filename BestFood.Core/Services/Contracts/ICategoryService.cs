using BestFood.Core.ViewModels.Category;

namespace BestFood.Core.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> All();
        Task CreateAsync(CreateCategoryViewModel model);
        Task EditAsync(CategoryViewModel model);

        Task<bool> Delete(int id);
		CategoryViewModel FindById(int id);
	}
}
