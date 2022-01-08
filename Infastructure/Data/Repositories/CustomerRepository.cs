using Core.Entities;
using Core.Interfaces.Gateways.Repositories;

namespace Infastructure.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AccountOwnerDbContext dbContext) : base(dbContext)
        {
        }
    }
}