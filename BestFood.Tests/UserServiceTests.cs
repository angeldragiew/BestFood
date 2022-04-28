using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Core.Services;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.User;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BestFood.Tests
{
    public class UserServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository<ApplicationUser>, Repository<ApplicationUser>>()
                .AddSingleton<IUserService, UserService>()
                .BuildServiceProvider();

            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();

            await SeedDbAsync(userRepo);
        }

        [Test]
        public void EditAsyncMustThrowOnUnknownUser()
        {
            var service = serviceProvider.GetService<IUserService>();

            var editUserViewModel = new EditUserViewModel()
            {
                Id="asdasd",
                FirstName="Angel",
                LastName="Petrov",
                PhoneNumber="13231234",
                Address="MyAddress"
            };

            Assert.CatchAsync<ArgumentException>(async () => await service.EditAsync(editUserViewModel), "Unknown user!");
        }

        [Test]
        public async Task EditAsyncMustEditUserWhenUserIdIsValid()
        {
            var service = serviceProvider.GetService<IUserService>();
            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();

            var editUserViewModel = new EditUserViewModel()
            {
                Id = "83a52d86-0f92-49b1-9bed-9910a722d4f5",
                FirstName = "EditedFirstname",
                LastName = "EditedLasttname",
                PhoneNumber = "852852852",
                Address = "EditedAddress"
            };

            await service.EditAsync(editUserViewModel);

            var editedUser = userRepo.All().FirstOrDefault(u => u.Id == editUserViewModel.Id);

            Assert.AreEqual(editUserViewModel.FirstName, editedUser.FirstName);
            Assert.AreEqual(editUserViewModel.LastName, editedUser.LastName);
            Assert.AreEqual(editUserViewModel.PhoneNumber, editedUser.PhoneNumber);
            Assert.AreEqual(editUserViewModel.Address, editedUser.Address);
        }

        [Test]
        public void GetUserProfileMustThrowOnUnknownUserName()
        {
            var service = serviceProvider.GetService<IUserService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.GetUserProfile("angasdl@gmaasdasil.com"), "Unknown user!");
        }

        [Test]
        public async Task GetUserProfileMustReturnUserViewModel()
        {
            var service = serviceProvider.GetService<IUserService>();
            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();

            var username = "angel@gmail.com";

            var userProfile = await service.GetUserProfile(username);

            var user = userRepo.All().FirstOrDefault(u => u.UserName == username);

            Assert.AreEqual(user.Id, userProfile.Id);
            Assert.AreEqual(user.FirstName, userProfile.FirstName);
            Assert.AreEqual(user.LastName, userProfile.LastName);
            Assert.AreEqual(user.PhoneNumber, userProfile.PhoneNumber);
            Assert.AreEqual(user.Email, userProfile.Email);
            Assert.AreEqual(user.Address, userProfile.Address);
        }

        [Test]
        public void GetUserForEditMustThrowOnUnknownId()
        {
            var service = serviceProvider.GetService<IUserService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.GetUserForEdit("asd"), "Unknown user!");
        }

        [Test]
        public async Task GetUserForEditMustReturnEditUserViewModel()
        {
            var service = serviceProvider.GetService<IUserService>();
            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();

            var id = "83a52d86-0f92-49b1-9bed-9910a722d4f5";

            var editUserViewModel = await service.GetUserForEdit(id);

            var user = userRepo.All().FirstOrDefault(u => u.Id == id);

            Assert.AreEqual(user.Id, editUserViewModel.Id);
            Assert.AreEqual(user.FirstName, editUserViewModel.FirstName);
            Assert.AreEqual(user.LastName, editUserViewModel.LastName);
            Assert.AreEqual(user.PhoneNumber, editUserViewModel.PhoneNumber);
            Assert.AreEqual(user.Address, editUserViewModel.Address);
        }

        [Test]
        public void GetUserByIdMustThrowOnUnknownId()
        {
            var service = serviceProvider.GetService<IUserService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.GetUserById("asd"), "Unknown user!");
        }

        [Test]
        public async Task GetUserByIdMustReturnUser()
        {
            var service = serviceProvider.GetService<IUserService>();
            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();

            var id = "83a52d86-0f92-49b1-9bed-9910a722d4f5";

            var userById = await service.GetUserById(id);

            var user = userRepo.All().FirstOrDefault(u => u.Id == id);

            Assert.AreEqual(user.Id, userById.Id);
            Assert.AreEqual(user.FirstName, userById.FirstName);
            Assert.AreEqual(user.LastName, userById.LastName);
            Assert.AreEqual(user.PhoneNumber, userById.PhoneNumber);
            Assert.AreEqual(user.Address, userById.Address);
        }

        [Test]
        public async Task GetUsersMustReturnAllUsers()
        {
            var service = serviceProvider.GetService<IUserService>();
            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();

            var users = await service.GetUsers();

            Assert.That(users.Count() > 0);
            Assert.That(users.Any(u => u.Id == "83a52d86-0f92-49b1-9bed-9910a722d4f5"));
        }

        [Test]
        public async Task GetUserAddressAndPhoneNUmberShouldReturnAddressAndPhoneIfTheyAreSet()
        {
            var service = serviceProvider.GetService<IUserService>();
            var userRepo = serviceProvider.GetService<IRepository<ApplicationUser>>();

            var addressAndPhone = await service.GetUserAddressAndPhoneNUmber("angel@gmail.com");

            Assert.That(addressAndPhone.PhoneNumber== "123456789");
            Assert.That(addressAndPhone.Address== "MyAddress");
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository<ApplicationUser> userRepo)
        {

            var user = new ApplicationUser
            {
                Id = "83a52d86-0f92-49b1-9bed-9910a722d4f5", // primary key
                UserName = "angel@gmail.com",
                NormalizedUserName = "ANGEL@GMAIL.COM",
                Email = "angel@gmail.com",
                NormalizedEmail = "ANGEL@GMAIL.COM",
                Address="MyAddress",
                PhoneNumber="123456789"
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            var hashed = hasher.HashPassword(user, "Angel12345.");
            user.PasswordHash = hashed;

            if (userRepo.All().Any(u => u.Id == user.Id) == false)
            {
                await userRepo.AddAsync(user);
                await userRepo.SaveChangesAsync();
            }
        }
    }
}
