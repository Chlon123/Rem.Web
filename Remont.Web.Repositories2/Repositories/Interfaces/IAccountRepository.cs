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
        IEnumerable<Account> GetAccounts();
        bool IsAccountCreated(Account accountToCheck);
        int GetAccountId(Account account);
        RepositoryActionResult<Account> UpdateAccount(Account accountToUpdate);
        RepositoryActionResult<Account> DeleteAccount(int id);
        object GetSortedAccountsWithFields(string sortingParameter, List<string> listOfFields);
        object CreateDataShapeObject(Account accountToShape, List<string> listOfFields);


    }
}
