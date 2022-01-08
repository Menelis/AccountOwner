using System.Threading.Tasks;
using Core.Dto.UseCaseResponses.CustomerResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.UseCases.CustomerUseCases;
using Moq;
using Xunit;

namespace Core.Tests.UseCases.CustomerUseCases
{
    public class CreateOrUpdateCustomerUnitTest
    {
        [Fact]
        public async Task Can_Create_Customer()
        {
            // Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(_ => _.Add(It.IsAny<Customer>()))
                            .ReturnsAsync(new Customer());
            
            // The Use Case and Start Test
            var useCase = new CreateOrUpdateCustomerUseCase(mockCustomerRepository.Object);

            // The output port
            var mockOutputPort = new Mock<IOutputPort<CreateOrUpdateCustomerResponse>>();
            mockOutputPort.Setup(_ => _.Handle(It.IsAny<CreateOrUpdateCustomerResponse>()));

            // Act
            var response = await useCase.Handle(new Dto.UseCaseRequests.CustomerRequests.CreateOrUpdateCustomerRequest("testName", "Test Surname"), mockOutputPort.Object);


            // Assert
            Assert.True(response);

        } 

    }
}