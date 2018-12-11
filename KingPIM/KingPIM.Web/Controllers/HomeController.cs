using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(UserManager<IdentityUser>userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Category");
            }

            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword(AccountViewModel vm)
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            var userVm = new AccountViewModel
            {
                Email = user.Email,
            };
            
            return View(userVm);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(AccountViewModel vm)
        {
            if(vm.Password != vm.ConfirmPassword)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            string code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, code, vm.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("Logout", "Account");
            }

            return RedirectToAction("ChangePassword");
        }
        
    }
}