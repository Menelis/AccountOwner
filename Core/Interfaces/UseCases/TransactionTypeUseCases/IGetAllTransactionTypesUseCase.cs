using Core.Dto.UseCaseRequests.TransactionTypeRequests;
using Core.Dto.UseCaseResponses.TransactionTypeResponses;

namespace Core.Interfaces.UseCases.TransactionTypeUseCases
{
    public interface IGetAllTransactionTypesUseCase : IUseCaseRequestHandler<GetAllTransactionTypesRequests, GetAllTransactionTypesResponse>
    {
    }
}