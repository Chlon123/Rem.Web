using Remont.Web.Models;
using Remont.Web.Repositories;
using Remont.Web.Repositories2.Repositories.EnumClasses;
using Remont.Web.Repositories2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories2.Repositories
{
    public class AUConnectionRepository : IAUConnectingRepository
    {
        private readonly RepositoryDbContext _context;

        public AUConnectionRepository()
        {
            _context = new RepositoryDbContext();
        }

        public RepositoryActionResult<User> ConnectUserWithAccount(User userToConnect, Account accountToConnect)
        {
            try
            {
                if (userToConnect == null || accountToConnect == null)
                {
                    return new RepositoryActionResult<User>(userToConnect, RepositoryActionStatus.NotFound);
                }

                User userToCon = _context.Users
                    .Where(u => u.UserId == userToConnect.UserId)
                    .FirstOrDefault();

                Account accountToCon = _context.Accounts
                    .Where(a => a.AccountId == accountToConnect.AccountId)
                    .FirstOrDefault();

                userToCon.UserEmailAdressHash = accountToCon.AccountEmailAsLoginHash;
                accountToCon.AccountOfUserId = userToCon.UserId;

                _context.SaveChanges();

                var checkUser = _context.Users.Where(u => u.UserEmailAdressHash == userToConnect.UserEmailAdressHash).FirstOrDefault();

                if (checkUser == null)
                {
                    return new RepositoryActionResult<User>(checkUser, RepositoryActionStatus.NotFound);
                }
                else
                {
                    return new RepositoryActionResult<User>(checkUser, RepositoryActionStatus.Connected);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
