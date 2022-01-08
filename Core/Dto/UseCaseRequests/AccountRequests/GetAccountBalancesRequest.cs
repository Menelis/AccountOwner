using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.AccountRequests
{
    public class GetAccountBalancesRequest : IUseCaseRequest<GetAccountBalancesResponse>
    {
        public string AccountNumber { get; }

        public GetAccountBalancesRequest(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }
}