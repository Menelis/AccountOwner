using Core.Dto.UseCaseResponses.AccountTypeResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.AccountTypeRequests
{
    public class GetAllAccountTypeRequest : IUseCaseRequest<GetAllAccountTypesResponse>
    {
        public GetAllAccountTypeRequest(){}
    }
}