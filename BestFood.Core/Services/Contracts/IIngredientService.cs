using BestFood.Core.ViewModels.Ingredient;

namespace BestFood.Core.Services.Contracts
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientViewModel>> All();

        Task CreateAsync(CreateIngredientViewModel model);

        Task EditAsync(EditIngredientViewModel model);

        Task Delete(string id);

        Task<EditIngredientViewModel> FindById(string id);


        Task<IEnumerable<IngredientCategoryViewModel>> LoadCategoriesForCreate();

        Task<IEnumerable<IngredientCategoryViewModel>> LoadCategoriesForEdit(string id);
    }
}
