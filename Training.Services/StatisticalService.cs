using Training.Contracts.Dto;
using Training.Contracts.Services;
using Training.Repostitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Services
{
    public class StatisticalService : IStatisticalService
    {
        IStatisticalRepository statisticalRepository;

        public StatisticalService(IStatisticalRepository statisticalRepository)
        {
            this.statisticalRepository = statisticalRepository;
        }

        public List<AccountDto> GetAccountsFromEighteenToThirtyFiveTearsOld()
        {
            return statisticalRepository.GetAccountsFromEighteenToThirtyFiveTearsOld().Select(x => new AccountDto
            {
                Id = x.Id,
                Balance = x.Balance,
                Birthday = x.Birthday,
                Email = x.Email,
                Username = x.Username,
                Password = x.Password,
                FullName = x.FullName,
                Phone = x.Phone,

            }).ToList();
        }

        public List<AccountDto> GetAccountsFromThirtyFiveToFortyFiveYearsOld()
        {
            return statisticalRepository.GetAccountsFromThirtyFiveToFortyFiveYearsOld().Select(x => new AccountDto
            {
                Id = x.Id,
                Balance = x.Balance,
                Birthday = x.Birthday,
                Email = x.Email,
                Username = x.Username,
                Password = x.Password,
                FullName = x.FullName,
                Phone = x.Phone,

            }).ToList();
        }

        public List<AccountDto> GetAccountsOverFortyFiveYearsOld()
        {
            return statisticalRepository.GetAccountsOverFortyFiveYearsOld().Select(x => new AccountDto
            {
                Id = x.Id,
                Balance = x.Balance,
                Birthday = x.Birthday,
                Email = x.Email,
                Username = x.Username,
                Password = x.Password,
                FullName = x.FullName,
                Phone = x.Phone,

            }).ToList();
        }

        public List<AccountDto> GetAccountsUnderEighteenYearsOld()
        {
            return statisticalRepository.GetAccountsUnderEighteenYearsOld().Select(x => new AccountDto
            {
                Id = x.Id,
                Balance = x.Balance,
                Birthday = x.Birthday,
                Email = x.Email,
                Username = x.Username,
                Password = x.Password,
                FullName = x.FullName,
                Phone = x.Phone,

            }).ToList();
        }
    }
}
