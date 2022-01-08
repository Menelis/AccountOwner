using Core.Dto.UseCaseRequests.CustomerRequests;
using Core.Dto.UseCaseResponses.CustomerResponses;

namespace Core.Interfaces.UseCases.CustomerUseCases
{
    public interface ICreateOrUpdateCustomerUseCase : IUseCaseRequestHandler<CreateOrUpdateCustomerRequest, CreateOrUpdateCustomerResponse>
    {
         
    }
}