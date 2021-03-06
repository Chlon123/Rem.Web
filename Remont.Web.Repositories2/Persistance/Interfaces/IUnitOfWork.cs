﻿using Remont.Web.Repositories.Repositories.Interfaces;
using Remont.Web.Repositories2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Persistance
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountsRepository { get; set; }
        IUserRepository UsersRepository { get; set; }
        IListOfFields ListOfFields { get; set; }
        void Complete();


    }
}
