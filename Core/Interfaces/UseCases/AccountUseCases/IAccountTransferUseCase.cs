using Core.Dto.UseCaseRequests.AccountRequests;
using Core.Dto.UseCaseResponses.AccountResponses;

namespace Core.Interfaces.UseCases.AccountUseCases
{
    public interface IAccountTransferUseCase  : IUseCaseRequestHandler<AccountTransferRequest, AccountTransferResponse>
    {

    }
}