using BestFood.Core.ViewModels.Product;

namespace BestFood.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> All();

        Task<IEnumerable<ProductCategoryViewModel>> LoadCategoriesForCreate();

        Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id);

        Task CreateAsync(CreateProductViewModel model);

        Task<bool> CategoryExists(int id);
    }
}
