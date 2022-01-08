using System;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.AccountRequests
{
    public class AccountTransferRequest : IUseCaseRequest<AccountTransferResponse>
    {
        public string SourceAccountNumber { get; }
        public string DestinationAccountNumber { get; }
        public decimal Amount { get; }

        public AccountTransferRequest(string sourceAccountNumber, string destinationAccountNumber, decimal amount)
        {
            SourceAccountNumber = sourceAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
            Amount = amount;
        }
    }
}