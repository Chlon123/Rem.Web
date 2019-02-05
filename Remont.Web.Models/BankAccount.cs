using Remont.Web.Models.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models
{
    public class BankAccount : BankAccountAbstractBase
    {
        public virtual User Owner { get; set; }

        public int? OwnerId { get; set; }
    }
}
