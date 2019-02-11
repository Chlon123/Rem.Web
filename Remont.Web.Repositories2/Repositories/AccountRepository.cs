using Remont.Web.Models;
using Remont.Web.Repositories.Repositories.Interfaces;
using Remont.Web.Repositories2.Repositories;
using Remont.Web.Repositories2.Repositories.EnumClasses;
using Remont.Web.Repositories2.Repositories.RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Remont.Web.Repositories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RepositoryDbContext _context;

        public AccountRepository(RepositoryDbContext context)
        {
            _context = context;
        }


        public Account CreateAccount(Account accountToCreate)
        {

            Account newAcc = new Account()
            {
            AccountEmailAsLogin = accountToCreate.AccountEmailAsLogin,
            AccountPassword = accountToCreate.AccountPassword,
            DateCreated = DateTime.Now,
            LastModified = DateTime.Now,
            };

            _context.Accounts.Add(newAcc);
            _context.SaveChanges();

            return newAcc;

        }

        public bool IsAccountCreated(Account accountToCheck)
        {
            var check = _context.Accounts
                        .Where(a => a.AccountEmailAsLogin == accountToCheck.AccountEmailAsLogin).FirstOrDefault();

            if (check != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts
                .SingleOrDefault(a => a.AccountId == id);
        }


        public int GetAccountId(Account account)
        {
            //return account.AccountId;
            return GetAccounts()
                .Where(a => a.AccountId == account.AccountId)
                .Select(a => a.AccountId)
                .SingleOrDefault();
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }


        public RepositoryActionResult<Account> UpdateAccount(Account accountToUpdate)
        {
            try
            {
                // you can only update when an expensegroup already exists for this id
                var existingAcc = _context.Accounts.FirstOrDefault(a => a.AccountId == accountToUpdate.AccountId);

                if (existingAcc == null)
                {
                    return new RepositoryActionResult<Account>(accountToUpdate, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set orginal entity state to detached
                _context.Entry(existingAcc).State = EntityState.Detached;

                // attach & save
                _context.Accounts.Attach(accountToUpdate);

                // set the updated entity state to modified, so it gets updated.
                _context.Entry(accountToUpdate).State = EntityState.Modified;

                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return new RepositoryActionResult<Account>(accountToUpdate, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Account>(accountToUpdate, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public RepositoryActionResult<Account> DeleteAccount(int id)
        {
            try
            {
                var accountToDelete = _context.Accounts.Where(a => a.AccountId == id).FirstOrDefault();

                if (accountToDelete == null)
                {
                    return new RepositoryActionResult<Account>(accountToDelete, RepositoryActionStatus.NotFound);
                }

                _context.Accounts.Remove(accountToDelete);
                _context.SaveChanges();

                if (_context.Accounts.Where(a => a.AccountId == accountToDelete.AccountId).FirstOrDefault() != null)
                {
                    return new RepositoryActionResult<Account>(accountToDelete, RepositoryActionStatus.NothingModified);
                }
                else
                {
                    return new RepositoryActionResult<Account>(accountToDelete, RepositoryActionStatus.Deleted);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetSortedAccountsWithFields(string sortingParameter, List<string> listOfFields)
        {
            var sortedAccounts = _context.Accounts
                .ApplySort(sortingParameter)
                .ToList()
                .Select(acc => CreateDataShapeObject(acc, listOfFields));

            return sortedAccounts;
        }

        //public IEnumerable<Account> GetSortedAAccountsWithFields(string sortingParameter, List<string> listOfFields)
        //{
        //    var sortedAccounts = _context.Accounts
        //        .ApplySort(sortingParameter)
        //        .ToList()
        //        .Select(acc => new Account()
        //        {
        //            AccountId = acc.AccountId,
        //            AccountEmailAsLogin = acc.AccountEmailAsLogin,
        //            AccountPassword = acc.AccountPassword,
        //            DateCreated = acc.DateCreated,
        //            LastModified = acc.LastModified,
        //        });

        //    return sortedAccounts;
        //}

        public object CreateDataShapeObject(Account accountToShape, List<string> listOfFields)
        {
            if (!listOfFields.Any())
            {
                return accountToShape;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in listOfFields)
                {
                    var fieldValue = accountToShape.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(accountToShape, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }
        }


    }
}
