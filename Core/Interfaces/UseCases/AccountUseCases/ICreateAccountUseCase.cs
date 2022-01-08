using Core.Dto.UseCaseRequests.AccountRequests;
using Core.Dto.UseCaseResponses.AccountResponses;

namespace Core.Interfaces.UseCases.AccountUseCases
{
    /// <summary>
    /// Create new customer use case
    /// </summary>
    public interface ICreateAccountUseCase : IUseCaseRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {
         
    }
}