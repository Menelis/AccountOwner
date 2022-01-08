using System;
using System.Threading.Tasks;
using Core.Dto.UseCaseRequests.CustomerRequests;
using Core.Dto.UseCaseResponses.CustomerResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.UseCases.CustomerUseCases;

namespace Core.UseCases.CustomerUseCases
{
    public class CreateOrUpdateCustomerUseCase : ICreateOrUpdateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateOrUpdateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(CreateOrUpdateCustomerRequest message, IOutputPort<CreateOrUpdateCustomerResponse> outputPort)
        {
            Customer customer = new()
            {
                FirstName = message.FirstName,
                LastName = message.LastName
            };
            if(message.Id == null)
            {
                await _customerRepository.Add(customer);
                outputPort.Handle(new CreateOrUpdateCustomerResponse(true, "Customer created successfully"));  
                return true;               
            }
            customer.Id = message.Id ?? new int();
            await _customerRepository.Update(customer, customer.Id);
            
            outputPort.Handle(new CreateOrUpdateCustomerResponse(true, "Customer has been updated successfully"));
            return true;
        }
    }
}