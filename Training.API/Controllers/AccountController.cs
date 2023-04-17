using Training.Common.Exceptions;
using Training.Contracts.Dto;
using Training.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class AccountController : ControllerBase
    {
        private IAccountService accountService;
        private ILogger<AccountController> logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            this.accountService = accountService;
            this.logger = logger;
        }

        [HttpPost]
        public AccountDto Add(AccountDto account)
        {

            try
            {
                return accountService.Add(account);
            }
            catch (BusinessException ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new BusinessException(ex.Message, ex);
            }
        }
        [HttpPut]
        public AccountDto Update(AccountDto account)
        {
            try
            {
                return accountService.Update(account);
            }
            catch (BusinessException ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new BusinessException(ex.Message, ex);
            }
        }
        [HttpDelete]
        public int Delete([FromRoute] int id)
        {
            try
            {
                return accountService.Delete(id);
            }
            catch (BusinessException ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new BusinessException(ex.Message, ex);
            }
        }
        [HttpGet("{id}")]
        public AccountDto Get([FromRoute] int id)
        {
            try
            {
                return accountService.Get(id);
            }
            catch (BusinessException ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new BusinessException(ex.Message, ex);
            }

        }
        [HttpGet]
        [Route("getAll")]
        public List<AccountDto> GetAll()
        {
            try
            {
                return accountService.GetAll();
            }
            catch (BusinessException ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new BusinessException(ex.Message, ex);
            }

        }
    }
}
