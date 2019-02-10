using Remont.Web.Models;
using Remont.Web.Repositories2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {

        User CreateUser(User userToCreate);
        User GetUserById (int id);
        IEnumerable<User> GetUsers();
        bool IsUserCreated(User userToCheck);
        int GetUserId(User user);
        RepositoryActionResult<User> UpdateUser(User userToUpdate);
        RepositoryActionResult<User> DeleteUser(int id);
    }
}
