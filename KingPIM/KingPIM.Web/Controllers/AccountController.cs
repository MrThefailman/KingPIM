using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using KingPIM.Web.Infrastructure;
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
        private readonly PasswordService _passwordService;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, PasswordService passwordService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _passwordService = passwordService;
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
        
        [Authorize(Roles = "Admin")]
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
        
        public async Task<IActionResult> ForgotPassword(AccountViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.Email);
                if (user == null)
                {
                    ViewBag.Message = "Something went wrong, try again";
                    return RedirectToAction("ForgotPassword", "Home");
                }
                string userId = user.Id;
                string code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action(
                    controller: "Account",
                    action: "ResetPassword",
                    values: new { userId = user.Id, code }, 
                    protocol: Request.Scheme);

                var smtpClient = new SmtpClient
                {
                    Host = "localhost",
                    Port = 25,
                    UseDefaultCredentials = true
                };

                var msg = new MailMessage("KingPIM@support.se", $"{vm.Email}")
                {
                    Subject = "Forgot Password, KingPIM",
                    IsBodyHtml = true,
                    Body = $"Kindly change your password by following " +
                    $"<a href={callbackUrl}>this link</a>"
                };

                smtpClient.Send(msg);
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public async Task<IActionResult> ResetPassword(AccountViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.HomeMessage = "Something went wrong, please try again";
                return RedirectToAction("Index", "Home");
            }
            var user = await _userManager.FindByEmailAsync(vm.Email);

            var result = await _userManager.ResetPasswordAsync(user, vm.Code, vm.Password);
            if (result.Succeeded)
            {
                ViewBag.HomeMessage = "Your password has been reset!";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.HomeMessage = "Something went wrong, please try again";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string userId, string code)
        {
            if(userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);

            var vm = new AccountViewModel
            {
                Email = user.Email,
                Code = code
            };
            
            return View(vm);
        }
    }
}