using BestFood.Core.ViewModels.Category;

namespace BestFood.Core.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CreateCategoryViewModel> All();
        Task CreateAsync(CreateCategoryViewModel model);
    }
}
