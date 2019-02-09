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

        public User CreateUser(User newUser, Account accountToConnectWith)
        {
            User createdUser = new User()
            {
                UserSpecializations = newUser.UserSpecializations,
                UserPhoneNumber = newUser.UserPhoneNumber,
                UserEmailAdress = accountToConnectWith.AccountEmailAsLogin,
                UserYearsOfExperience = newUser.UserYearsOfExperience,
                DescriptionOfUser = newUser.DescriptionOfUser,
                Name = newUser.Name,
                LastName = newUser.Name,
                BirthDate = newUser.BirthDate,
                Age = newUser.Age,
                City = newUser.City,
                State = newUser.State,
                PostalCode = newUser.PostalCode,
                Country = newUser.Country,
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };

            _context.Users.Add(createdUser);
            _context.SaveChanges();

            return createdUser;
        }
    }
}
