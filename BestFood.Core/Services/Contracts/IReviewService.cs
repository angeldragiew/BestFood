using BestFood.Core.ViewModels.Review;

namespace BestFood.Core.Services.Contracts
{
    public interface IReviewService
    {
        Task RateProdcutAsync(CreateReviewViewModel model, string username);

        Task Delete(string id);

        Task EditAsync(EditReviewViewModel model);

        Task<EditReviewViewModel> FindByIdAsync(string id);
    }
}
