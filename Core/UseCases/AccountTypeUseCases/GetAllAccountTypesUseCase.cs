using System.Threading.Tasks;
using Core.Dto.UseCaseRequests.AccountTypeRequests;
using Core.Dto.UseCaseResponses.AccountTypeResponses;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.AccountTypeUseCases;

namespace Core.UseCases.AccountTypeUseCases
{
    public class GetAllAccountTypesUseCase : IGetAllAccountTypesUseCase
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public GetAllAccountTypesUseCase(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }
        public async Task<bool> Handle(GetAllAccountTypeRequest message, IOutputPort<GetAllAccountTypesResponse> outputPort)
        {
            var accountTypes = await _accountTypeRepository.ListAll();
            if(accountTypes.Count == 0)
            {
                outputPort.Handle(new GetAllAccountTypesResponse(message: "No Account Types were found"));
                return false;
            }
            outputPort.Handle(new GetAllAccountTypesResponse(accountTypes));
            return true;
        }
    }
}