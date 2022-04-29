using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.User;
using BestFood.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
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

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            var user = await userService.GetUserProfile(User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var user = await userService.GetUserForEdit(id);
                return View(user);
            }
            catch (ArgumentException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("MyProfile", "User");
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
                TempData[MessageConstant.SuccessMessage] = "Profile editted successfully!";
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }

            return RedirectToAction("MyProfile", "User");
        }
    }
}
