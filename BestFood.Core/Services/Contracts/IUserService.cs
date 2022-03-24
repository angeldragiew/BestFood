using BestFood.Core.ViewModels.User;
using BestFood.Infrastructure.Data.Models;

namespace BestFood.Core.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsers();

        Task<EditUserViewModel> GetUserForEdit(string id);

        Task EditAsync(EditUserViewModel model);

        Task<ApplicationUser> GetUserById(string id);
    }
}
