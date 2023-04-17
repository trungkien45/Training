using Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Repostitories.Interface
{
    public interface IStatisticalRepository : IBaseRepository
    {
        List<Account> GetAccountsFromEighteenToThirtyFiveTearsOld();
        List<Account> GetAccountsFromThirtyFiveToFortyFiveYearsOld();
        List<Account> GetAccountsOverFortyFiveYearsOld();
        List<Account> GetAccountsUnderEighteenYearsOld();
    }
}
