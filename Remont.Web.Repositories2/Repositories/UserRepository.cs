using Remont.Web.Models;
using Remont.Web.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RepositoryDbContext _context;

        public UserRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetUserNameById(int userId)
        {
            return _context.Users
                .Where(u => u.UserId == userId)
                .Select(u => u.Name)
                .ToList();
        }

        public IEnumerable<string> GetUserLastNameById(int userId)
        {
            return _context.Users
                .Where(u => u.UserId == userId)
                .Select(u => u.LastName)
                .ToList();
        }
    }
}
