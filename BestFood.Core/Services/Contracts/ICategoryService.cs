using BestFood.Core.ViewModels.Category;

namespace BestFood.Core.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> All();
        Task CreateAsync(CreateCategoryViewModel model);
        Task EditAsync(EditCategoryViewModel model);

        Task Delete(int id);
        Task<EditCategoryViewModel> FindById(int id);
	}
}
