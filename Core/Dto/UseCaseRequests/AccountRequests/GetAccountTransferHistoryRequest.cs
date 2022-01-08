using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.AccountRequests
{
    public class GetAccountTransferHistoryRequest : IUseCaseRequest<GetAccountTransferHistoryResponse>
    {
        public string AccountNumber { get; }

        public GetAccountTransferHistoryRequest(string accountNumber) 
        {
            AccountNumber = accountNumber;
        }
    }
}