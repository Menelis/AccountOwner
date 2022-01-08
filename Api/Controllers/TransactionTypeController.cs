using System.Threading.Tasks;
using Api.Presenters.TransactionTypePresenters;
using Core.Interfaces.UseCases.TransactionTypeUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionTypeController : ControllerBase
    {
        private readonly IGetAllTransactionTypesUseCase _getAllTransactionTypesUseCase;
        private readonly GetAllTransactionTypesPresenter _getAllTransactionTypesPresenter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="getAllTransactionTypesUseCase"></param>
        /// <param name="getAllTransactionTypesPresenter"></param>
        public TransactionTypeController(IGetAllTransactionTypesUseCase getAllTransactionTypesUseCase, GetAllTransactionTypesPresenter getAllTransactionTypesPresenter)
        {
            _getAllTransactionTypesUseCase = getAllTransactionTypesUseCase;
            _getAllTransactionTypesPresenter = getAllTransactionTypesPresenter;
        }
        /// <summary>
        /// Returns a list of Transaction Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _getAllTransactionTypesUseCase.Handle(new Core.Dto.UseCaseRequests.TransactionTypeRequests.GetAllTransactionTypesRequests(), _getAllTransactionTypesPresenter);
            return _getAllTransactionTypesPresenter.ContentResult;
        }
    }
}