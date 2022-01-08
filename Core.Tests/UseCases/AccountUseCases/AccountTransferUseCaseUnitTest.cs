using System;
using System.Threading.Tasks;
using Core.Dto.UseCaseResponses.AccountResponses;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.UseCases.AccountUseCases;
using Moq;
using Xunit;

namespace Core.Tests.UseCases.AccountUseCases
{
    public class AccountTransferUseCaseUnitTest
    {
        [Fact]
        public async Task Cannot_Transfer_Insuffient_Funds()
        {
            // Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRepository.Setup(_ => _.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Entities.Account()
                {
                    Id = 1,
                    Balance = 0
                });
            var mockAccountTransaction = new Mock<IAccountTransactionRepository>();


            // The use case start test
            var useCase = new AccountTransferUseCase(mockAccountRepository.Object, mockAccountTransaction.Object);

            // The output Port
            var mockOutputPort = new Mock<IOutputPort<AccountTransferResponse>>();
            mockOutputPort.Setup(_ => _.Handle(It.IsAny<AccountTransferResponse>()));

            //Act
            var response = await useCase.Handle(new Dto.UseCaseRequests.AccountRequests.AccountTransferRequest(Guid.NewGuid().ToString().ToUpper(), Guid.NewGuid().ToString().ToUpper(), 10), mockOutputPort.Object);

            
            // Assert
            Assert.False(response);

        }
    }
}