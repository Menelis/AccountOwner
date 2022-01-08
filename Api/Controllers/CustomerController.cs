using System.Threading.Tasks;
using Api.Presenters.CustomerPresenters;
using Core.Interfaces.UseCases.CustomerUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IGetAllCustomersUseCase _getAllCustomersUseCase;
        private readonly GetAllCustomersPresenter _getAllCustomersPresenter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getAllCustomersUseCase"></param>
        /// <param name="getAllCustomersPresenter"></param>
        public CustomerController(IGetAllCustomersUseCase getAllCustomersUseCase, GetAllCustomersPresenter getAllCustomersPresenter)
        {
            _getAllCustomersUseCase = getAllCustomersUseCase;
            _getAllCustomersPresenter = getAllCustomersPresenter;
        }
        /// <summary>
        /// Returns a list of customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _getAllCustomersUseCase.Handle(new Core.Dto.UseCaseRequests.CustomerRequests.GetAllCustomersRequest(), _getAllCustomersPresenter);
            return _getAllCustomersPresenter.ContentResult;
        }
    }
}