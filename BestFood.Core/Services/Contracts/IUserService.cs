using BestFood.Core.ViewModels.User;
using BestFood.Infrastructure.Data.Models;

namespace BestFood.Core.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsers();

        Task<ApplicationUser> GetUserById(string id);

        Task<EditUserViewModel> GetUserForEdit(string id);

        Task<UserViewModel> GetUserProfile(string username);
        Task EditAsync(EditUserViewModel model);
        Task<UserAddressAndPhoneNumber> GetUserAddressAndPhoneNUmber(string username);
    }
}
