using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories2.Repositories.Interfaces
{
    public interface IListOfFields
    {
        List<string> CreateListOfFields(string fields);
    }
}
