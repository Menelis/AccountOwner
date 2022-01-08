using System.Threading.Tasks;
using Core.Dto.UseCaseRequests.AccountRequests;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.AccountUseCases;

namespace Core.UseCases.AccountUseCases
{
    public class GetAllAccountsUseCase : IGetAllAccountsUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public GetAllAccountsUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<bool> Handle(GetAllAccountsRequest message, IOutputPort<GetAllAccountsResponse> outputPort)
        {
            var accounts = await _accountRepository.ListAll();
            if(accounts.Count == 0)
            {
                outputPort.Handle(new GetAllAccountsResponse(message:"No accounts where found."));
                return false;
            }
            outputPort.Handle(new GetAllAccountsResponse(accounts));
            return true;
        }
    }
}