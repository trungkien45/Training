using Training.Entities;

namespace Training.Repostitories.Interface
{
    public interface IAccountRepository : IBaseRepository
    {
        Account Update(Account accountEdit);

        Account? CheckDuplicate(Account newAccount);
        int Detele(int id);
        Account? Get(int id);
        List<Account> GetAll();
        Account Add(Account newAccount);
        Account GetByUserName(string username);
    }
}