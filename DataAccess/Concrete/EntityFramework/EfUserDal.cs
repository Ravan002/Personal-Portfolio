using DataAccess.Abstract;
using Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal(ProjectContext context) : BaseRepository<User>(context), IUserDal
    {
        private readonly ProjectContext _context = context;

        public async Task<List<User>> GetAllUsersWithRole()
        {
            var result = await _context.Users
                 .Include(u => u.RoleClaim)
                 .ToListAsync();
            return result;
        }
    }
}
