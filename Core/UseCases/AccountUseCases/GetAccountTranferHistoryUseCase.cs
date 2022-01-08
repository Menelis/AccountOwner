using System.Threading.Tasks;
using Core.Dto.UseCaseRequests.AccountRequests;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.AccountUseCases;

namespace Core.UseCases.AccountUseCases
{
    public class GetAccountTranferHistoryUseCase : IGetAccountTranferHistoryUseCase
    {
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IAccountRepository _accountRepository;

        public GetAccountTranferHistoryUseCase(IAccountTransactionRepository accountTransactionRepository, IAccountRepository accountRepository)
        {
            _accountTransactionRepository = accountTransactionRepository;
            _accountRepository = accountRepository;
        }
        public async Task<bool> Handle(GetAccountTransferHistoryRequest message, IOutputPort<GetAccountTransferHistoryResponse> outputPort)
        {
            // For live application this should use stored procedure to improve performance
            Account account = await _accountRepository.GetAccountByAccountNumber(message.AccountNumber);
            if(account is null)
            {
                outputPort.Handle(new GetAccountTransferHistoryResponse(message:$"No account exists with account number:{message.AccountNumber}"));
                return false;
            }
            var accountTransfers = await _accountTransactionRepository.List(transaction => transaction.AccountId == account.Id && transaction.TransactionTypeId == (int)Constants.TransactionType.TRANSFER);
            if(accountTransfers.Count == 0)
            {
                outputPort.Handle(new GetAccountTransferHistoryResponse(message:"No Transfers were performed on this account"));
                return false;
            }
            outputPort.Handle(new GetAccountTransferHistoryResponse(accountTransfers));
            return true;
        }
    }
}