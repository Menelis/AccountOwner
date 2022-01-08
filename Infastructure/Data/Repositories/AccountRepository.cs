using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Gateways.Repositories;

namespace Infastructure.Data.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(AccountOwnerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CustomerAccountTypeExists(int customerId, int accountTypeId)
        {
            var customerAccountTypeExists = await GetSingleBySpec(account => account.CustomerId == customerId && account.AccountTypeId == accountTypeId);
            return customerAccountTypeExists is not null;
        }

        public async Task<Account> GetAccountByAccountNumber(string accountNumber)
        {
            var account = await GetSingleBySpec(account => account.AccountNumber.ToLower() == accountNumber.ToLower());
            return account;
        }
    }
}