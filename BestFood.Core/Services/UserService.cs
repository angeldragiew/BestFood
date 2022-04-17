using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.User;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> repo;

        public UserService(IRepository<ApplicationUser> repo)
        {
            this.repo = repo;
        }

        public async Task EditAsync(EditUserViewModel model)
        {
            ApplicationUser user = await repo.All().FirstOrDefaultAsync(u => u.Id == model.Id);

            if (user == null)
            {
                throw new ArgumentNullException("Unknown user!");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;

            await repo.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUserProfile(string username)
        {
            var user = await repo
                .All()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Address = u.Address,
                })
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException("Unknown user!");
            }

            return user;
        }

        public async Task<EditUserViewModel> GetUserForEdit(string id)
        {
            var user = await repo
                .All()
                .Select(u => new EditUserViewModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Address = u.Address,
                    PhoneNumber = u.PhoneNumber,
                })
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentException("Unknown user!");
            }

            return user;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await repo.All()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException("Unknown user!");
            }

            return user;
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All()
                .Select(x => new UserListViewModel
                {
                    Id = x.Id,
                    Name = $"{x.FirstName} {x.LastName}",
                    Email = x.Email,
                }).ToListAsync();
        }

        public async Task<UserAddressAndPhoneNumber> GetUserAddressAndPhoneNUmber(string username)
        {
            var user = await repo
                .All()
                .FirstOrDefaultAsync(u => u.UserName == username);

            var addressAndNumber = new UserAddressAndPhoneNumber();

            if (user != null)
            {
                addressAndNumber.Address = user.Address;
                addressAndNumber.PhoneNumber = user.PhoneNumber;
            }

            return addressAndNumber;
        }
    }
}
