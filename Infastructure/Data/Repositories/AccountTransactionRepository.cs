using Core.Entities;
using Core.Interfaces.Gateways.Repositories;

namespace Infastructure.Data.Repositories
{
    public class AccountTransactionRepository : RepositoryBase<AccountTransaction>, IAccountTransactionRepository
    {
        public AccountTransactionRepository(AccountOwnerDbContext dbContext) : base(dbContext)
        {
        }
    }
}