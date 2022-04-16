using BestFood.Core.ViewModels.Product;
using BestFood.Core.ViewModels.Review;

namespace BestFood.Core.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductDetailsViewModel> Details(string id);

        Task<IEnumerable<ProductViewModel>> All(int id);

        Task CreateAsync(CreateProductViewModel model);

        Task EditAsync(EditProductViewModel model);

        Task Delete(string id);

        Task<EditProductViewModel> FindById(string id);

        Task<IEnumerable<ProductCategoryViewModel>> LoadCategoriesForCreate();

        Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id);
        Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id, string productId);
        Task<IEnumerable<ProductReviewViewModel>> LoadReviewsForProduct(string productId);

        Task<bool> CategoryExists(int? id);
    }
}
