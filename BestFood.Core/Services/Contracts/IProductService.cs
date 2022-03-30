using BestFood.Core.ViewModels.Product;

namespace BestFood.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> All(int id);


        Task CreateAsync(CreateProductViewModel model);

        Task EditAsync(EditProductViewModel model);

        Task Delete(string id);

        Task<EditProductViewModel> FindById(string id);

        Task<IEnumerable<ProductCategoryViewModel>> LoadCategoriesForCreate();

        Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id);
        Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id, string productId);

        Task<bool> CategoryExists(int id);
    }
}
