using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.User;
using BestFood.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestFoodWebApp.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public UserController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ManageUsers()
        {
            var users = await userService.GetUsers();

            return View(users);
        }

        public async Task<IActionResult> Roles(string id)
        {
            try
            {
                var user = await userService.GetUserById(id);
                var model = new UserRolesViewModel()
                {
                    UserId = id,
                    Name = $"{user.FirstName} {user.LastName}",

                };

                ViewBag.RoleItems = roleManager.Roles
                    .ToList()
                    .Select(r => new SelectListItem()
                    {
                        Text = r.Name,
                        Value = r.Id,
                        Selected = userManager.IsInRoleAsync(user, r.Name).Result
                    });

                return View(model);
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("ManageUsers", "User");
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await userService.GetUserForEdit(id);
                return View(model);
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("ManageUsers", "User");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid data!";
                return View(model);
            }

            try
            {
                await userService.EditAsync(model);
                TempData[MessageConstant.SuccessMessage] = "Successfully edited!";
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }

            return RedirectToAction("ManageUsers", "User");
        }



        public async Task<IActionResult> CreateRole()
        {
            //await roleManager.CreateAsync(new IdentityRole()
            //{
            //    Name = "Administrator"
            //});

            return Ok();
        }
    }
}
