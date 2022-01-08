using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Core.Interfaces.Gateways.Repositories;
using Core.UseCases.AccountUseCases;
using Core.Interfaces;
using Core.Dto.UseCaseResponses.AccountResponses;

namespace Core.Tests.UseCases.AccountUseCases
{
    public class CreateAccountUseCaseUnitTest
    {
        [Fact]
        public async Task Cannot_Create_Account_Account_Type_Exists_For_Customer()
        {
            // Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRepository.Setup(_ => _.CustomerAccountTypeExists(It.IsAny<int>(), It.IsAny<int>()))
                    .ReturnsAsync(true);
            

            // The use case and start test
            var useCase = new CreateAccountUseCase(mockAccountRepository.Object);

            // The output port
            var mockOutputPort = new Mock<IOutputPort<CreateAccountResponse>>();
            mockOutputPort.Setup(_ => _.Handle(It.IsAny<CreateAccountResponse>()));

            // Act
            var response = await useCase.Handle(new Dto.UseCaseRequests.AccountRequests.CreateAccountRequest(1, 2, 10), mockOutputPort.Object);

            // Assert
            Assert.False(response);            
        }

        [Fact]
        public async Task Cannot_Create_Account_Invalid_Deposit_Amount()
        {
            // Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRepository.Setup(_ => _.CustomerAccountTypeExists(It.IsAny<int>(), It.IsAny<int>()))
                    .ReturnsAsync(false);
            
            // The use case and start testing
            var useCase = new CreateAccountUseCase(mockAccountRepository.Object);

            // The output port
            var mockOutputPort = new Mock<IOutputPort<CreateAccountResponse>>();
            mockOutputPort.Setup(_ => _.Handle(It.IsAny<CreateAccountResponse>()));

            // Act
            var response = await useCase.Handle(new Dto.UseCaseRequests.AccountRequests.CreateAccountRequest(1, 2, 0), mockOutputPort.Object);

            // Assert
            Assert.False(response);
        }

        [Fact]
        public async Task Can_CreateAccount()
        {
            // Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRepository.Setup(_ => _.CustomerAccountTypeExists(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(false);
            
            // The use case and start testing
            var useCase = new CreateAccountUseCase(mockAccountRepository.Object);

            // Output Port
            var mockOutputPort= new Mock<IOutputPort<CreateAccountResponse>>();
            mockOutputPort.Setup(_ => _.Handle(It.IsAny<CreateAccountResponse>()));

            // Act
            var response = await useCase.Handle(new Dto.UseCaseRequests.AccountRequests.CreateAccountRequest(1, 2, 500), mockOutputPort.Object);

            
            // Assert
            Assert.True(response);
        }
    }
}