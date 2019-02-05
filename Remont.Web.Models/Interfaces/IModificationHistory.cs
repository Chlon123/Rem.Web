using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models.Interfaces
{
    public interface IModificationHistory
    {
        DateTime? DateCreated { get; set; }

        DateTime? LastModified { get; set; }
    }
}
