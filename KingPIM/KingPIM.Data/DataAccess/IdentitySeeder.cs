using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPIM.Data.DataAccess
{
    public class IdentitySeeder : IIdentitySeeder
    {
        //private RoleManager roleManager;
        //public async Task<bool> CreateAdminAccountIfEmpty()
        //{
        //    bool x = await _roleManager

        //    return true;
        //}




        private const string _admin = "admin";
        private const string _password = "buggeroff";

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentitySeeder(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> CreateAdminAccountIfEmpty()
        {
            if (!_context.Users.Any(u => u.UserName == _admin))
            {
                var user = new IdentityUser
                {
                    UserName = _admin,
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, _password);
                var test = result.Succeeded;
            }
            return true;

        }
    }
}
