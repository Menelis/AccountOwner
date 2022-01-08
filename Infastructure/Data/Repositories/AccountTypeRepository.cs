using Core.Entities;
using Core.Interfaces.Gateways.Repositories;

namespace Infastructure.Data.Repositories
{
    public class AccountTypeRepository : RepositoryBase<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(AccountOwnerDbContext dbContext) : base(dbContext)
        {
        }
    }
}