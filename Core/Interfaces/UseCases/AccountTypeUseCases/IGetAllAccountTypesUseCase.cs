using Core.Dto.UseCaseRequests.AccountTypeRequests;
using Core.Dto.UseCaseResponses.AccountTypeResponses;

namespace Core.Interfaces.UseCases.AccountTypeUseCases
{
    public interface IGetAllAccountTypesUseCase : IUseCaseRequestHandler<GetAllAccountTypeRequest, GetAllAccountTypesResponse>
    {
         
    }
}