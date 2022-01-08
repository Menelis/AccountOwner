using System;
using System.Threading.Tasks;
using Core.Constants;
using Core.Dto.UseCaseRequests.AccountRequests;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.AccountUseCases;

namespace Core.UseCases.AccountUseCases
{
    public class AccountTransferUseCase : IAccountTransferUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        
        public AccountTransferUseCase(IAccountRepository accountRepository,
                                      IAccountTransactionRepository accountTransactionRepository)
        {
            _accountRepository = accountRepository;
            _accountTransactionRepository = accountTransactionRepository;
        }
        public async Task<bool> Handle(AccountTransferRequest message, IOutputPort<AccountTransferResponse> outputPort)
        {
            // check if Source and Destination Accounts Exists
            var sourceAccount = await _accountRepository.GetAccountByAccountNumber(message.SourceAccountNumber);
            if(sourceAccount is null)
            {
                outputPort.Handle(new AccountTransferResponse(message:$"No Account with id: {message.SourceAccountNumber} exists"));
                return false;
            }
            var destinationAccount = await _accountRepository.GetAccountByAccountNumber(message.DestinationAccountNumber);
            if(destinationAccount is null)
            {
                outputPort.Handle(new AccountTransferResponse(message:$"No Account with id: {message.DestinationAccountNumber} exists"));
                return false;
            }

            // Check if Source Account balance  has enough balance for transfer
            if(sourceAccount.Balance < message.Amount)
            {
                outputPort.Handle(new AccountTransferResponse(message:$"The amount {message.Amount} exceeds balance"));
                return false;
            }

            // Transfer amount
            await UpdateAnyAccount(sourceAccount, message.Amount, Constants.TransactionType.TRANSFER);
            await UpdateAnyAccount(destinationAccount, message.Amount, Constants.TransactionType.DEPOSIT);

            // Transaction history
            await  PerformTransaction(sourceAccount, Constants.TransactionType.TRANSFER, message.Amount);
            await PerformTransaction(destinationAccount, Constants.TransactionType.DEPOSIT, message.Amount);

            outputPort.Handle(new AccountTransferResponse(true, "Transfer was successful"));
            return true;

        }
        /// <summary>
        /// Update any account based on the transaction Type
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        private async Task UpdateAnyAccount(Account account, decimal amount, Constants.TransactionType transactionType)
        {
            switch(transactionType)
            {
                case Constants.TransactionType.DEPOSIT:
                    account.Balance += amount;
                    break;
                case Constants.TransactionType.WITHDRAWAL:
                case Constants.TransactionType.TRANSFER:
                    account.Balance -= amount;
                    break;
            }
            await _accountRepository.Update(account, account.Id);
        }
        /// <summary>
        /// Perform any Transaction History
        /// </summary>
        /// <param name="account"></param>
        /// <param name="transactionType"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private async Task PerformTransaction(Account account, Constants.TransactionType transactionType, decimal amount)
        {
            await _accountTransactionRepository.Add(new AccountTransaction 
            {
                AccountId = account.Id,
                TransactionTypeId = (int)transactionType,
                Amount = amount
            });
        }

    }
}