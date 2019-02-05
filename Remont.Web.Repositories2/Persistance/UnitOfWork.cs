using Remont.Web.Repositories.Repositories;
using Remont.Web.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext _context;

        public IAccountRepository Accounts { get; set; }
        public IUserRepository Users { get; set; }

        public UnitOfWork(RepositoryDbContext context)
        {
            _context = context;
            Accounts = new AccountRepository(context);
            Users = new UserRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }



    }
}
