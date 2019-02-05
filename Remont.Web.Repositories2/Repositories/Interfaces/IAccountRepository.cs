using Remont.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Repositories.Interfaces
{
     public interface IAccountRepository
    {
        IEnumerable<string> GetAccountEmailById(int accountId);

        IEnumerable<string> GetPasswordByAccountId(int accountId);

        bool DoesAccountHasEmail(string emailToCheck);

        bool DoesAccountHasPassword(string password);

        IEnumerable<Account> GetAccounts();

        string GetEmail(Account account);

        Account GetAccountById(int id);

        int GetAccountId(Account account);

        bool IsAccountCreated(Account accountToCreate);

        Account AddAccount(Account accountToCreate);

        IEnumerable<Account> GetSingleAccount(Account account);


    }
}
