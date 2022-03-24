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
            var user = await repo.All()
               .FirstOrDefaultAsync(u=>u.Id == model.Id);

            if (user == null)
            {
                throw new AggregateException("Unknown user!");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            await repo.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await repo.All()
                .FirstOrDefaultAsync(u => u.Id == id);

            if(user == null)
            {
                throw new ArgumentNullException("Unknown user!");
            }

            return user;
        }

        public async Task<EditUserViewModel> GetUserForEdit(string id)
        {
            var user = await repo.All()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException("Unknown user");
            }

            return new EditUserViewModel()
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
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
    }
}
