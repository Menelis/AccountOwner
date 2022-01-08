using System;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Gateways.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        /// <summary>
        /// Returns true if the customer already has the account type else false
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="accountTypeId"></param>
        /// <returns></returns>
         Task<bool> CustomerAccountTypeExists(int customerId, int accountTypeId);
         /// <summary>
         /// Returns Account details that matches the provided id
         /// </summary>
         /// <param name="accountNumber"></param>
         /// <returns></returns>
         Task<Account> GetAccountByAccountNumber(string accountNumber);
    }
}