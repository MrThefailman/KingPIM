using KingPIM.Data;
using KingPIM.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPIM.Web.Infrastructure
{
    public class PasswordService
    {
        private ApplicationDbContext ctx;
        private UserManager<IdentityUser> _userManager;
        public PasswordService(ApplicationDbContext context, UserManager<IdentityUser> usermanager)
        {
            ctx = context;
            _userManager = usermanager;
        }
        public async void ChangePasswordAsync(AccountViewModel vm)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(vm.Email);

            if(user == null)
            {
                return;
            }
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, vm.Password);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return;
            }
        }

    }
}
