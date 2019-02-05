using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Models.AbstractClasses
{
    public abstract class BankAccountAbstractBase
    {
        public int BankAccountId { get; set; }

        public decimal BankAccountIncome { get; set; }

        public decimal BankAccountOutcome { get; set; }

        public decimal BankAccountBalance { get; set; }
    }
}
