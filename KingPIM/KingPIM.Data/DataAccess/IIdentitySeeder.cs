using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPIM.Data.DataAccess
{
    public interface IIdentitySeeder
    {
        Task<bool> CreateAdminAccountIfEmpty();
    }
}
