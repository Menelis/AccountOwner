using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.AccountResponses
{
    public class GetAccountTransferHistoryResponse : UseCaseResponseMessage, ITEntitiesResponse<AccountTransaction>
    {
        public GetAccountTransferHistoryResponse(bool success = false, string message = null) : base(success, message){}

        public GetAccountTransferHistoryResponse(IEnumerable<AccountTransaction> entities, bool success = true,  string message = null) : base(success, message)
        {
            Entities = entities;
        }
        public IEnumerable<AccountTransaction> Entities  { get; }
    }
}