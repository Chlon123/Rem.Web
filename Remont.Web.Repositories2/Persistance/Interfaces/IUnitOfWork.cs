using Remont.Web.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Persistance
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; set; }
        IUserRepository Users { get; set; }

        void Complete();


    }
}
