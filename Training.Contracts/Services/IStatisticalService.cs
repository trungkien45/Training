using Training.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Contracts.Services
{
    public interface IStatisticalService
    {
        List<AccountDto> GetAccountsFromEighteenToThirtyFiveTearsOld();
        List<AccountDto> GetAccountsFromThirtyFiveToFortyFiveYearsOld();
        List<AccountDto> GetAccountsOverFortyFiveYearsOld();
        List<AccountDto> GetAccountsUnderEighteenYearsOld();
    }
}
