using Remont.Web.Models;
using Remont.Web.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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

        public Account AddAccount(Account accountToCreate)
        {
            _context.Accounts.Add(accountToCreate);
            //GetAccounts()
            //.Select(a => new Account
            //{
            //    AccountId = a.AccountId,
            //    AccountEmailAsLogin = a.AccountEmailAsLogin,
            //    AccountPassword = a.AccountPassword,
            //    DateCreated = DateTime.Now,
            //    LastModified = DateTime.Now
            //});
            _context.SaveChanges();

            return accountToCreate;
        }

        public bool IsAccountCreated(Account accountToCheck)
        {
            var check = _context.Accounts
                        .Where(a => a.AccountEmailAsLogin == accountToCheck.AccountEmailAsLogin);

            if (check.FirstOrDefault() != null)
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
                .FirstOrDefault();
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

    }
}
