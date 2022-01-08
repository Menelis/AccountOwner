using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;

namespace Core.Dto.UseCaseResponses.CustomerResponses
{
    public class GetAllCustomersResponse : UseCaseResponseMessage, ITEntitiesResponse<Customer>
    {
        public GetAllCustomersResponse(bool success = false, string message = null) : base(success, message){}

        public GetAllCustomersResponse(IEnumerable<Customer> entities, bool success = true, string message = null) : base(success, message)
        {
            Entities = entities;
        }
        public IEnumerable<Customer> Entities { get; }
    }
}