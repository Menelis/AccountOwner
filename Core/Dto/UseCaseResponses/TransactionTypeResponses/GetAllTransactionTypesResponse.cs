using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.TransactionTypeResponses
{
    public class GetAllTransactionTypesResponse : UseCaseResponseMessage, ITEntitiesResponse<TransactionType>
    {
        public GetAllTransactionTypesResponse(bool success = false, string message = null) : base(success, message){}

        public GetAllTransactionTypesResponse(IEnumerable<TransactionType> entities, bool success = true, string message = null) : base(success, message)
        {
            Entities = entities;
        }
        public IEnumerable<TransactionType> Entities  { get; }
    }
}