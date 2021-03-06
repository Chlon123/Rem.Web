﻿using Remont.Web.Repositories.Repositories;
using Remont.Web.Repositories.Repositories.Interfaces;
using Remont.Web.Repositories2.Repositories;
using Remont.Web.Repositories2.Repositories.Helpers;
using Remont.Web.Repositories2.Repositories.Interfaces;
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
        public IAccountRepository AccountsRepository { get; set; }
        public IUserRepository UsersRepository { get; set; }
        public IListOfFields ListOfFields { get; set; }

        public UnitOfWork(RepositoryDbContext context)
        {
            _context = context;
            AccountsRepository = new AccountRepository(context);
            UsersRepository = new UserRepository(context);
            ListOfFields = new ListOfFields();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }



    }
}
