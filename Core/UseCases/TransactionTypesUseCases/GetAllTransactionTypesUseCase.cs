using System.Threading.Tasks;
using Core.Dto.UseCaseRequests.TransactionTypeRequests;
using Core.Dto.UseCaseResponses.TransactionTypeResponses;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.TransactionTypeUseCases;

namespace Core.UseCases.TransactionTypesUseCases
{
    public class GetAllTransactionTypesUseCase : IGetAllTransactionTypesUseCase
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        public GetAllTransactionTypesUseCase(ITransactionTypeRepository transactionTypeRepository)
        {
            _transactionTypeRepository = transactionTypeRepository;
        }
        public async Task<bool> Handle(GetAllTransactionTypesRequests message, IOutputPort<GetAllTransactionTypesResponse> outputPort)
        {
            var transactionTypes = await _transactionTypeRepository.ListAll();
            outputPort.Handle(new GetAllTransactionTypesResponse(transactionTypes));
            return true;
        }
    }
}