using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.AccountRequests
{
    public class GetAllAccountsRequest : IUseCaseRequest<GetAllAccountsResponse>
    {
        public GetAllAccountsRequest(){}
    }
}