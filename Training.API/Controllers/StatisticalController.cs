using Training.Common.Exceptions;
using Training.Contracts.Dto;
using Training.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticalController : ControllerBase
    {
        private IStatisticalService statisticalService;
        private ILogger<AccountController> logger;
        public StatisticalController(IStatisticalService statisticalService, ILogger<AccountController> logger)
        {
            this.statisticalService = statisticalService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("GetAccountsUnderEighteenYearsOld")]
        public List<AccountDto> GetAccountsUnderEighteenYearsOld()
        {
            try
            {
                return statisticalService.GetAccountsUnderEighteenYearsOld();
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
        [Route("GetAccountsFromEighteenToThirtyFiveTearsOld")]
        public List<AccountDto> GetAccountsFromEighteenToThirtyFiveTearsOld()
        {
            try
            {
                return statisticalService.GetAccountsFromEighteenToThirtyFiveTearsOld();
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
        [Route("GetAccountsFromThirtyFiveToFortyFiveYearsOld")]
        public List<AccountDto> GetAccountsFromThirtyFiveToFortyFiveYearsOld()
        {
            try
            {
                return statisticalService.GetAccountsFromThirtyFiveToFortyFiveYearsOld();
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
        [Route("GetAccountsOverFortyFiveYearsOld")]
        public List<AccountDto> GetAccountsOverFortyFiveYearsOld()
        {
            try
            {
                return statisticalService.GetAccountsOverFortyFiveYearsOld();
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
