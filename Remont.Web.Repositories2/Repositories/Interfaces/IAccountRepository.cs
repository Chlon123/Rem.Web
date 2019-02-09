using Remont.Web.Models;
using Remont.Web.Repositories2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Repositories.Interfaces
{
     public interface IAccountRepository
    {
        Account CreateAccount(Account accountToCreate);
        Account GetAccountById(int id);
        IEnumerable<string> GetAccountEmailById(int accountId);
        IEnumerable<string> GetPasswordByAccountId(int accountId);
        IEnumerable<Account> GetAccounts();
        IEnumerable<Account> GetSingleAccount(Account account);
        bool DoesAccountHasEmail(string emailToCheck);
        bool DoesAccountHasPassword(string password);
        bool IsAccountCreated(Account accountToCreate);
        string GetEmail(Account account);
        int GetAccountId(Account account);
        RepositoryActionResult<Account> UpdateAccount(Account account);
        RepositoryActionResult<Account> DeleteAccount(int id);

    }
}
