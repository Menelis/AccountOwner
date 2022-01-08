using System.Collections.Generic;
using Core.Entities;

namespace Core.Dto.UseCaseResponses.AccountResponses
{
    public class GetAllAccountsResponse : Interfaces.UseCaseResponseMessage, ITEntitiesResponse<Entities.Account>
    {
        public GetAllAccountsResponse(bool success = false, string message = null) : base(false, message){}

        public GetAllAccountsResponse(IEnumerable<Account> entities, bool success = true, string message = null) : base(success, message)
        {
            Entities = entities;
        }
        public IEnumerable<Account> Entities { get; }
    }
}