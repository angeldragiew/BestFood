using BestFood.Core.ViewModels.Product;

namespace BestFood.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductCategoryViewModel>> LoadCategoriesForCreate();

        Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id);
    }
}
