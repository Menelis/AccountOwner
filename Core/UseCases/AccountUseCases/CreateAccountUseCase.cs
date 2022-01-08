using System;
using System.Threading.Tasks;
using Core.Dto.UseCaseRequests.AccountRequests;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.AccountUseCases;

namespace Core.UseCases.AccountUseCases
{
    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<bool> Handle(CreateAccountRequest message, IOutputPort<CreateAccountResponse> outputPort)
        {
            // Check if initial deposit is not less than or equal 0
            if(message.Balance <= 0)
            {
                outputPort.Handle(new CreateAccountResponse(message:"The initial deposit amount cannot be less than 0"));
                return false;
            }
            // Check if the current user does not have the account type already(eg. Savings twice)         
            bool customerAccountTypeExists = await _accountRepository.CustomerAccountTypeExists(message.CustomerId, message.AccountTypeId);
            if(customerAccountTypeExists)
            {
                outputPort.Handle(new CreateAccountResponse(message:"Customer already has this Account Type.Only one Account Type per customer allowed"));
                return false;
            }

            Account account = new()
            {
                AccountTypeId = message.AccountTypeId,
                CustomerId = message.CustomerId,
                Balance = message.Balance,
                AccountNumber = Guid.NewGuid().ToString().ToUpper() // in real work application this will be generated based on requirements for  account number
            };
            
            await _accountRepository.Add(account);
            outputPort.Handle(new CreateAccountResponse(account.Id));


            return true;
        }
    }
}