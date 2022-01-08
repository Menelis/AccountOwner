using System.Threading.Tasks;
using Api.Presenters.AccountTypePresenters;
using Core.Interfaces.UseCases.AccountTypeUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountTypeController : ControllerBase
    {
        private readonly IGetAllAccountTypesUseCase _getAllAccountTypesUseCase;
        private readonly GetAccountTypesPresenter _getAccountTypesPresenter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="getAllAccountTypesUseCase"></param>
        /// <param name="getAccountTypesPresenter"></param>
        public AccountTypeController(IGetAllAccountTypesUseCase getAllAccountTypesUseCase, GetAccountTypesPresenter getAccountTypesPresenter)
        {
            _getAllAccountTypesUseCase = getAllAccountTypesUseCase;
            _getAccountTypesPresenter = getAccountTypesPresenter;
        }
        /// <summary>
        /// Returns a list of Account Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _getAllAccountTypesUseCase.Handle(new Core.Dto.UseCaseRequests.AccountTypeRequests.GetAllAccountTypeRequest(), _getAccountTypesPresenter);
            return _getAccountTypesPresenter.ContentResult;
        }

    }
}