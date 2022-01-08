using Core.Dto.UseCaseResponses.TransactionTypeResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.TransactionTypeRequests
{
    public class GetAllTransactionTypesRequests : IUseCaseRequest<GetAllTransactionTypesResponse>
    {
        public GetAllTransactionTypesRequests(){}
    }
}