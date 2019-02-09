using Remont.Web.Models;
using Remont.Web.Repositories.Repositories.Interfaces;
using Remont.Web.Repositories2.Repositories;
using Remont.Web.Repositories2.Repositories.EnumClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public bool DoesAccountHasEmail(string emailToCheck)
        {

            if (_context.Accounts
                .Where(a => a.AccountEmailAsLogin == emailToCheck)
                .Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DoesAccountHasPassword(string password)
        {
            if (_context.Accounts
                .Where(a=>a.AccountPassword == password)
                .Any())
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

        public IEnumerable<string> GetAccountEmailById(int accountId)
        {
            return _context.Accounts
                .Where(a => a.AccountId == accountId)
                .Select(a => a.AccountEmailAsLogin)
                .ToList();
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

        public string GetEmail(Account account)
        {
            return account.AccountEmailAsLogin;
        }

        public IEnumerable<string> GetPasswordByAccountId(int accountId)
        {
            return _context.Accounts
                .Where(a => a.AccountId == accountId)
                .Select(a => a.AccountPassword)
                .ToList();

        }

        public IEnumerable<Account> GetSingleAccount(Account account)
        {
            var lookedAcc = GetAccounts()
                                .Where(a => a.AccountId == account.AccountId)
                                .ToList();
            return lookedAcc;
        }

        public RepositoryActionResult<Account> UpdateAccount(Account account)
        {
            try
            {
                // you can only update when an expensegroup already exists for this id
                var existingAcc = _context.Accounts.FirstOrDefault(a => a.AccountId == account.AccountId);

                if (existingAcc == null)
                {
                    return new RepositoryActionResult<Account>(account, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set orginal entity state to detached
                _context.Entry(existingAcc).State = EntityState.Detached;

                // attach & save
                _context.Accounts.Attach(account);

                // set the updated entity state to modified, so it gets updated.
                _context.Entry(account).State = EntityState.Modified;

                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return new RepositoryActionResult<Account>(account, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Account>(account, RepositoryActionStatus.NothingModified, null);
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
    }
}
