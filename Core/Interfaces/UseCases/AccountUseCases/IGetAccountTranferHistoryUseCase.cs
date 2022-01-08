using Core.Dto.UseCaseRequests.AccountRequests;
using Core.Dto.UseCaseResponses.AccountResponses;

namespace Core.Interfaces.UseCases.AccountUseCases
{
    public interface IGetAccountTranferHistoryUseCase : IUseCaseRequestHandler<GetAccountTransferHistoryRequest, GetAccountTransferHistoryResponse> 
    {
        
    }
}