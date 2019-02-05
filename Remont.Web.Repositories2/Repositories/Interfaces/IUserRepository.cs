using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<string> GetUserNameById(int userId);
        IEnumerable<string> GetUserLastNameById(int userId);

    }
}
