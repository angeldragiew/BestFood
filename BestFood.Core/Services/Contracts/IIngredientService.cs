using BestFood.Core.ViewModels.Ingredient;

namespace BestFood.Core.Services.Contracts
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientViewModel>> All();
        Task CreateAsync(CreateIngredientViewModel model);
    }
}
