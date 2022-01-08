using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Core.Dto.UseCaseRequests.CustomerRequests;
using Core.Dto.UseCaseResponses.CustomerResponses;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.CustomerUseCases;

namespace Core.UseCases.CustomerUseCases
{
    public class GetAllCustomersUseCase : IGetAllCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(GetAllCustomersRequest message, IOutputPort<GetAllCustomersResponse> outputPort)
        {
            var customers = await _customerRepository.ListAll();
            if(customers.Count == 0)
            {
                outputPort.Handle(new GetAllCustomersResponse(message:"No customers found in the database"));
                return false;
            }

            outputPort.Handle(new GetAllCustomersResponse(customers));
            return true;
        }
    }
}