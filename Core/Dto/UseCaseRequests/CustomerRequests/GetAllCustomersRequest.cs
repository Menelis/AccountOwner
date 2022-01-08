using Core.Dto.UseCaseResponses.CustomerResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.CustomerRequests
{
    public class GetAllCustomersRequest : IUseCaseRequest<GetAllCustomersResponse>
    {
        public GetAllCustomersRequest(){}
    }
}