using Core.Entities;
using Core.Interfaces.Gateways.Repositories;

namespace Infastructure.Data.Repositories
{
    public class TransactionTypeRepository : RepositoryBase<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(AccountOwnerDbContext dbContext) : base(dbContext)
        {
        }
    }
}