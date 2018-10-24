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
        private const string _admin = "admin";
        private const string  _password = "buggeroff";

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentitySeeder(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> CreateAdminAccountIfEmpty()
        {
            if(!_context.Users.Any(u => u.UserName == _admin))
            {
                await _userManager.CreateAsync(new IdentityUser
                {
                    UserName = _admin,
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                }, _password);
            }

            // TODO: Admin Roles & make admin top role

            return true;
        }
    }
}
