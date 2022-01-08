using Core.Entities;
using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.AccountResponses
{
    public class GetAccountBalancesResponse : UseCaseResponseMessage, ITEntityResponse<Account>
    {
        /// <summary>
        /// Constructor for failure(No account found)
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public GetAccountBalancesResponse(bool success = false, string message = null) : base(success, message){}
        /// <summary>
        /// Constructor for success(if the Account is found )
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public GetAccountBalancesResponse(Account entity, bool success = true, string message = null) : base(success, message)
        {
            Entity = entity;
        }
        public Account Entity { get; }
    }
}