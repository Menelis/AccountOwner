using System.Threading.Tasks;
using Core.Dto.UseCaseRequests.AccountRequests;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.AccountUseCases;

namespace Core.UseCases.AccountUseCases
{
    public class GetAccountBalancesUseCase : IGetAccountBalancesUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountBalancesUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> Handle(GetAccountBalancesRequest message, IOutputPort<GetAccountBalancesResponse> outputPort)
        {
            Account account = await _accountRepository.GetAccountByAccountNumber(message.AccountNumber);
            if(account is null)
            {
                outputPort.Handle(new GetAccountBalancesResponse(message: $"No Account exists with id:{message.AccountNumber}"));
                return false;
            }

            outputPort.Handle(new GetAccountBalancesResponse(account));
            return true;
        }
    }
}