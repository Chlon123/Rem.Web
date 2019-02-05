using Remont.Web.Models.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models
{
    public class UsersLocalization : LocalizationAbstractBase
    {
        public int UsersLocalizationId { get; set; }

        public virtual ICollection<User> LocalizationOfUsers { get; set; }
    }
}
