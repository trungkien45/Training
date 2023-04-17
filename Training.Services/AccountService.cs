using Training.Common;
using Training.Common.Exceptions;
using Training.Contracts.Dto;
using Training.Contracts.Services;
using Training.Entities;
using Training.Repostitories.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Training.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private byte[] key;
        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            this.accountRepository = accountRepository;
            key = Convert.FromBase64String(configuration["EncryptionKey"]);
        }

        public AccountDto Add(AccountDto account)
        {
            CheckInput(account);

            Account newAccount = new Account { Balance = account.Balance, Password = account.Password, Birthday = account.Birthday, Email = account.Email, FullName = account.FullName, Phone = account.Phone, Username = account.Username };

            Account? accountOld = accountRepository.CheckDuplicate(newAccount);
            if (accountOld != null)
            {
                Respone(account, accountOld);
            }
            newAccount = accountRepository.Add(newAccount);
            accountRepository.SaveCommit();
            account.Id = newAccount.Id;
            account.Password = string.Empty;
            return account;
        }

        private void CheckInput(AccountDto account)
        {
            if (string.IsNullOrEmpty(account.Username))
            {
                throw new BusinessException("Username Is Requied");
            }
            if (string.IsNullOrEmpty(account.Password))
            {
                throw new BusinessException("Password Is Requied");
            }
            if (string.IsNullOrEmpty(account.Email))
            {
                throw new BusinessException("Email Is Requied");
            }
            if (string.IsNullOrEmpty(account.Phone))
            {
                throw new BusinessException("Phone Is Requied");
            }
            if (account.Balance < 0)
            {
                throw new BusinessException("Balance cannot be less than zero");
            }
            account.Password = AesAlgorithm.AesEncryptString(account.Password, key);
        }

        public int Delete(int id)
        {
            var account = accountRepository.Get(id);
            if (account == null)
            {
                throw new BusinessException("Id not Existed");
            }
            var idafter = accountRepository.Detele(id);
            accountRepository.SaveCommit();
            return idafter;
        }

        public AccountDto Get(int id)
        {
            var account = accountRepository.Get(id);
            if (account == null)
            {
                throw new BusinessException("Id not Existed");
            }
            return new AccountDto
            {
                Balance = account.Balance,
                Birthday = account.Birthday,
                Email = account.Email,
                Username = account.Username,
                FullName = account.FullName,
                Phone = account.Phone,
                //Password = account.Password,
                Id = account.Id
            };
        }

        public List<AccountDto> GetAll()
        {
            return accountRepository.GetAll().Select(x => new AccountDto
            {
                Id = x.Id,
                Balance = x.Balance,
                Birthday = x.Birthday,
                Email = x.Email,
                Username = x.Username,
                //Password = x.Password,
                FullName = x.FullName,
                Phone = x.Phone,

            }).ToList();
        }

        public AccountDto Update(AccountDto account)
        {
            CheckInput(account);
            Account accountEdit = new Account { Id = account.Id, Password = account.Password, Balance = account.Balance, Birthday = account.Birthday, Email = account.Email, FullName = account.FullName, Phone = account.Phone, Username = account.Username };
            Account? accountOld = accountRepository.CheckDuplicate(accountEdit);
            if (accountOld != null && accountOld.Id != account.Id)
            {
                Respone(account, accountOld);
            }
            accountRepository.Update(accountEdit);
            account.Password = string.Empty;
            return account;

        }

        private static void Respone(AccountDto account, Account accountOld)
        {
            if (accountOld.Username == account.Username)
                throw new BusinessException("Username Duplicate");
            if (accountOld.Phone == account.Phone)
                throw new BusinessException("Phone Duplicate");
            if (accountOld.Email == account.Email)
                throw new BusinessException("Email Duplicate");
        }

        public AccountDto CheckLogin(string username, string password)
        {
            var encryptPassword = AesAlgorithm.AesEncryptString(password, key);
            Account account = accountRepository.GetByUserName(username);
            if (account == null)
            {
                return null;
            }
            if (account.Password != encryptPassword)
            {
                return null;
            }
            return new AccountDto
            {
                Balance = account.Balance,
                Birthday = account.Birthday,
                Email = account.Email,
                Username = account.Username,
                FullName = account.FullName,
                Phone = account.Phone,
                //Password = account.Password,
                Id = account.Id
            };
        }
    }
}
