using AutoMapper;
using Moq;
using CreditPaymentSystem.Application.Contracts.Persistence;
using CreditPaymentSystem.Application.Features.Purchases.Commands.Purchase;
using CreditPaymentSystem.Application.Profiles;
using CreditPaymentSystem.Application.UnitTests.Mocks;
using CreditPaymentSystem.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static CreditPaymentSystem.Domain.Common.Enums;

namespace CreditPaymentSystem.Application.UnitTests.Transactions.Commands
{
    public class PurchaseTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IBaseRepository<Transaction>> mockTransactionsRepository;
        private readonly Mock<ICustomerRepository> mockCustomerRepository;
        public PurchaseTests()
        {
            mockTransactionsRepository = RepositoryMocks.GetTransactionsRepository();
            mockCustomerRepository = new Mock<ICustomerRepository>();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Handle_InValidCustomerId_PurchaseWithImmediatePaymentOption()
        {
            //Arrange
            var handler = new PurchaseHandler(mockTransactionsRepository.Object, mapper, mockCustomerRepository.Object);
            // Act
            var result = await handler.Handle(new PurchaseCommand()
            {
                Amount = 100,
                Description = "Mobile Bill",
                CustomerId = Guid.Parse("{00000000-0000-0000-0000-000000000000}"),
                PaymentType = PaymentType.Immediate,
            }, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
        }
    }
}
