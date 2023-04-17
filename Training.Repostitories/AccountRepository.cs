using Training.Entities;
using Training.Repostitories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Training.Repostitories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {

        public AccountRepository(TrainingDbContext dbContext):base(dbContext)
        {
        }

        public Account Update(Account accountEdit)
        {
            dbContext.Entry(accountEdit).State = EntityState.Modified;
            return accountEdit;
        }

        public Account? CheckDuplicate(Account newAccount)
        {
            var account = dbContext.Accounts.Where(p=>p.Email == newAccount.Email||p.Phone==newAccount.Phone||p.Username==newAccount.Username).FirstOrDefault();
            return account;
        }

        public int Detele(int id)
        {
            var account = dbContext.Accounts.FirstOrDefault(x => x.Id == id);
            dbContext.Accounts.Remove(account);
            return account.Id;
        }

        public Account? Get(int id)
        {
            var account = dbContext.Accounts.FirstOrDefault(x => x.Id == id);
            return account;
        }

        public List<Account> GetAll()
        {
            return dbContext.Accounts.ToList();
        }

        public Account Add(Account newAccount)
        {
            return dbContext.Accounts.Add(newAccount).Entity;
        }

        public Account GetByUserName(string username)
        {
            var account = dbContext.Accounts.FirstOrDefault(x => x.Username == username);
            return account;
        }
    }
}
