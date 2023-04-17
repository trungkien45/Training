using Training.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Contracts.Services
{
    public interface IAccountService
    {
        AccountDto Add(AccountDto account);
        AccountDto Update(AccountDto account);
        int Delete(int id);
        AccountDto Get(int id);
        List<AccountDto> GetAll();
        AccountDto CheckLogin(string username, string password);
    }
}
