using Microsoft.Data.Sqlite;
using Training.Entities;
using Training.Repostitories.Interface;
using Microsoft.EntityFrameworkCore;
namespace Training.Repostitories
{
    public class StatisticalRepository : BaseRepository, IStatisticalRepository
    {
        public StatisticalRepository(TrainingDbContext dbContext) : base(dbContext)
        {
        }

        public List<Account> GetAccountsFromEighteenToThirtyFiveTearsOld()
        {
            return dbContext.Accounts.Where(p=> 35>= DateTime.Now.Year - p.Birthday.Year && DateTime.Now.Year - p.Birthday.Year >= 18 ).ToList();
        }

        public List<Account> GetAccountsFromThirtyFiveToFortyFiveYearsOld()
        {
            return dbContext.Accounts.Where(p => 45 >= DateTime.Now.Year - p.Birthday.Year && DateTime.Now.Year - p.Birthday.Year >= 35).ToList();
        }

        public List<Account> GetAccountsOverFortyFiveYearsOld()
        {
            return dbContext.Accounts.Where(p => DateTime.Now.Year - p.Birthday.Year > 45).ToList();
        }

        public List<Account> GetAccountsUnderEighteenYearsOld()
        {
            return dbContext.Accounts.Where(p => 18 > DateTime.Now.Year - p.Birthday.Year).ToList();
        }
    }
}
