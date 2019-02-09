using Remont.Web.Models;
using Remont.Web.Repositories;
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

        public void ConnectUserWithAccount(User userToConnect, Account accountToConnect)
        {
            User userToCon = _context.Users
                .Where(u => u.UserId == userToConnect.UserId)
                .FirstOrDefault();

            Account accountToCon = _context.Accounts
                .Where(a => a.AccountId == accountToConnect.AccountId)
                .FirstOrDefault();

            userToCon.UserEmailAdress = accountToCon.AccountEmailAsLogin;
            accountToCon.AccountOfUserId = userToCon.UserId;

            _context.SaveChanges();
        }
    }
}
