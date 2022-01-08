using System;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.AccountRequests
{
    public class CreateAccountRequest :  IUseCaseRequest<CreateAccountResponse>
    {
        public int AccountTypeId { get; }
        public int CustomerId { get; }
        public decimal Balance { get; }

        public CreateAccountRequest(int accountTypeId, int customerId, decimal balance)
        {
            AccountTypeId = accountTypeId;
            CustomerId = customerId;
            Balance = balance;
        }        
    }
}