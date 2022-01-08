using System.Threading.Tasks;
using Api.Presenters.AccountPresenters;
using Core.Interfaces.UseCases.AccountUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountTransferUseCase _accountTransferUseCase;
        private readonly AccountTransferPresenter _accountTransferPresenter;

        private readonly ICreateAccountUseCase _createAccountUseCase;
        private readonly CreateAccountPresenter _createAccountPresenter;

        private readonly IGetAccountBalancesUseCase _getAccountBalancesUseCase;
        private readonly GetAccountBalancesPresenter _getAccountBalancesPresenter;

        private readonly IGetAccountTranferHistoryUseCase _getAccountTranferHistoryUseCase;
        private readonly GetAccountTransferHistoryPresenter _getAccountTransferHistoryPresenter;

        private readonly IGetAllAccountsUseCase _getAllAccountsUseCase;
        private readonly GetAllAccountsPresenter _getAllAccountsPresenter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountTransferUseCase"></param>
        /// <param name="accountTransferPresenter"></param>
        /// <param name="createAccountUseCase"></param>
        /// <param name="createAccountPresenter"></param>
        /// <param name="getAccountBalancesUseCase"></param>
        /// <param name="getAccountBalancesPresenter"></param>
        /// <param name="getAccountTranferHistoryUseCase"></param>
        /// <param name="getAccountTransferHistoryPresenter"></param>
        /// <param name="getAllAccountsUseCase"></param>
        /// <param name="getAllAccountsPresenter"></param>
        public AccountController(IAccountTransferUseCase accountTransferUseCase, AccountTransferPresenter accountTransferPresenter,
                                 ICreateAccountUseCase createAccountUseCase, CreateAccountPresenter createAccountPresenter,
                                 IGetAccountBalancesUseCase getAccountBalancesUseCase, GetAccountBalancesPresenter getAccountBalancesPresenter,
                                 IGetAccountTranferHistoryUseCase getAccountTranferHistoryUseCase, GetAccountTransferHistoryPresenter getAccountTransferHistoryPresenter,
                                 IGetAllAccountsUseCase getAllAccountsUseCase, GetAllAccountsPresenter getAllAccountsPresenter)
        {
            _accountTransferUseCase = accountTransferUseCase;
            _accountTransferPresenter = accountTransferPresenter;

            _createAccountUseCase = createAccountUseCase;
            _createAccountPresenter = createAccountPresenter;

            _getAccountBalancesUseCase = getAccountBalancesUseCase;
            _getAccountBalancesPresenter = getAccountBalancesPresenter;

            _getAccountTranferHistoryUseCase = getAccountTranferHistoryUseCase;
            _getAccountTransferHistoryPresenter = getAccountTransferHistoryPresenter;

            _getAllAccountsUseCase = getAllAccountsUseCase;
            _getAllAccountsPresenter = getAllAccountsPresenter;
        }
        /// <summary>
        /// Transfer amount between two accounts
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Transfer")]
        public async Task<IActionResult> TrasferAmount(Models.Requests.AccountRequests.AccountTranferRequest request)
        {
            await _accountTransferUseCase.Handle(new Core.Dto.UseCaseRequests.AccountRequests.AccountTransferRequest(request.SourceAccountNumber, request.DestinationAccountNumber, request.Amount), _accountTransferPresenter);
            return _accountTransferPresenter.ContentResult;
        }
        /// <summary>
        /// Create new Account for customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("NewAccount")]
        public async Task<IActionResult> Post(Models.Requests.AccountRequests.CreateAccountRequest request)
        {
            await _createAccountUseCase.Handle(new Core.Dto.UseCaseRequests.AccountRequests.CreateAccountRequest(request.AccountTypeId, request.CustomerId, request.DepositAmount), _createAccountPresenter);
            return _createAccountPresenter.ContentResult;
        }
        /// <summary>
        /// Returns Account balances that matches the provided id
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("GetAccountBalancesByAccountNumber/{accountNumber}")]
        public async Task<IActionResult> GetAccountBalancesByAccountNumber(string accountNumber)
        {
            await _getAccountBalancesUseCase.Handle(new Core.Dto.UseCaseRequests.AccountRequests.GetAccountBalancesRequest(accountNumber), _getAccountBalancesPresenter);
            return _getAccountBalancesPresenter.ContentResult;
        }
        /// <summary>
        /// Returns a list of Transfers that has occurred on the account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("GetAcountTransfers/{accountNumber}")]
        public async Task<IActionResult> GetTransfers(string accountNumber)
        {
            await _getAccountTranferHistoryUseCase.Handle(new Core.Dto.UseCaseRequests.AccountRequests.GetAccountTransferHistoryRequest(accountNumber), _getAccountTransferHistoryPresenter);
            return _getAccountTransferHistoryPresenter.ContentResult;
        }
        /// <summary>
        /// Returns a list of all accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _getAllAccountsUseCase.Handle(new Core.Dto.UseCaseRequests.AccountRequests.GetAllAccountsRequest(), _getAllAccountsPresenter);
            return _getAllAccountsPresenter.ContentResult;
        }


    }
}