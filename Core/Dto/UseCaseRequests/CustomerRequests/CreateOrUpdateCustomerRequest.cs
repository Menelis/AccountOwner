using System;
using Core.Dto.UseCaseResponses.CustomerResponses;
using Core.Interfaces;

namespace Core.Dto.UseCaseRequests.CustomerRequests
{
    public class CreateOrUpdateCustomerRequest : IUseCaseRequest<CreateOrUpdateCustomerResponse>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int? Id { get; }

        public CreateOrUpdateCustomerRequest(string firstName, string lastName, int? id = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }
    }
}