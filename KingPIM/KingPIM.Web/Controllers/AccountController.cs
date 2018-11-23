using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.UserName);
                if(user != null)
                {
                    await _signInManager.SignOutAsync();
                    if((await _signInManager.PasswordSignInAsync(user, vm.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index", "Category");
                    }
                }
            }
            return RedirectToAction("Index", "Category", vm);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser(AccountViewModel vm)
        {
            var User = new IdentityUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(User, vm.Password);

            if (result.Succeeded)
            {
                var findByEmail = await _userManager.FindByEmailAsync(User.Email);
                await _userManager.AddToRoleAsync(findByEmail, vm.Role);
            }
            return RedirectToAction("Users");
        }
        
        [HttpGet]
        public IActionResult Users(AccountViewModel vm)
        {
            ViewBag.Title = "Users";

            var User = new AccountViewModel
            {
                Users = _userManager.Users,
                Roles = _roleManager.Roles
            };

            return View(User);
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangePassword(AccountViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var newPassword = vm.Password;
                IdentityUser identityUser = await _userManager.FindByNameAsync(username);
                var hashedNewPassword = _userManager.PasswordHasher.HashPassword(identityUser, newPassword);
                identityUser.PasswordHash = hashedNewPassword;
                var save = await _userManager.UpdateAsync(identityUser);
                var succeeded = save.Succeeded;
            }
            return RedirectToAction("Index");
        }

    }
}