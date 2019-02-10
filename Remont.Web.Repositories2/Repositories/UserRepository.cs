using Remont.Web.Models;
using Remont.Web.Repositories.Repositories.Interfaces;
using Remont.Web.Repositories2.Repositories;
using Remont.Web.Repositories2.Repositories.EnumClasses;
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

        public User CreateUser(User userToCreate)
        {
            User createdUser = new User()
            {
                UserSpecializations = userToCreate.UserSpecializations,
                UserPhoneNumber = userToCreate.UserPhoneNumber,
                UserYearsOfExperience = userToCreate.UserYearsOfExperience,
                DescriptionOfUser = userToCreate.DescriptionOfUser,
                Name = userToCreate.Name,
                LastName = userToCreate.Name,
                BirthDate = userToCreate.BirthDate,
                Age = userToCreate.Age,
                City = userToCreate.City,
                State = userToCreate.State,
                PostalCode = userToCreate.PostalCode,
                Country = userToCreate.Country,
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };

            _context.Users.Add(createdUser);
            _context.SaveChanges();

            return createdUser;
        }

        public RepositoryActionResult<User> DeleteUser(int id)
        {
            try
            {
                var userToDelete = _context.Users.Where(a => a.UserId == id).FirstOrDefault();

                if (userToDelete == null)
                {
                    return new RepositoryActionResult<User>(userToDelete, RepositoryActionStatus.NotFound);
                }

                _context.Users.Remove(userToDelete);
                _context.SaveChanges();

                if (_context.Users.Where(a => a.UserId == userToDelete.UserId).FirstOrDefault() != null)
                {
                    return new RepositoryActionResult<User>(userToDelete, RepositoryActionStatus.NothingModified);
                }
                else
                {
                    return new RepositoryActionResult<User>(userToDelete, RepositoryActionStatus.Deleted);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUserById(int id)
        {
            return _context.Users
                .SingleOrDefault(u => u.UserId == id);
        }

        public int GetUserId(User user)
        {
            return GetUsers()
                .Where(u => u.UserId == user.UserId)
                .Select(u => u.UserId)
                .SingleOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool IsUserCreated(User userToCheck)
        {
            var check = _context.Users
            .Where(u => u.UserId == userToCheck.UserId)
            .FirstOrDefault();

            if (check != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public RepositoryActionResult<User> UpdateUser(User userToUpdate)
        {
            try
            {
                // you can only update when an expensegroup already exists for this id
                var existingAcc = _context.Users.FirstOrDefault(a => a.UserId == userToUpdate.UserId);

                if (existingAcc == null)
                {
                    return new RepositoryActionResult<User>(userToUpdate, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set orginal entity state to detached
                _context.Entry(existingAcc).State = EntityState.Detached;

                // attach & save
                _context.Users.Attach(userToUpdate);

                // set the updated entity state to modified, so it gets updated.
                _context.Entry(userToUpdate).State = EntityState.Modified;

                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return new RepositoryActionResult<User>(userToUpdate, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<User>(userToUpdate, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
