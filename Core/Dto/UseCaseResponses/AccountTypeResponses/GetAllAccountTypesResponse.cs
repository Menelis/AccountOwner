using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.AccountTypeResponses
{
    public class GetAllAccountTypesResponse : UseCaseResponseMessage, ITEntitiesResponse<AccountType>
    {

        public GetAllAccountTypesResponse(bool success = false, string message = null) : base(success, message){}

        public GetAllAccountTypesResponse(IEnumerable<AccountType> entities, bool success = true, string message = null) : base(success, message)
        {
            Entities = entities;
        }
        public IEnumerable<AccountType> Entities { get; }
    }
}