using AutoMapper;
using Moq;
using Shouldly;
using SocieteGenerale.Application.Contracts.Persistence;
using SocieteGenerale.Application.Features.Customers.Commands.AddNewCustomer;
using SocieteGenerale.Application.Profiles;
using SocieteGenerale.Application.UnitTests.Mocks;
using SocieteGenerale.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SocieteGenerale.Application.UnitTests.Customers.Commands
{
    public class AddNewCustomerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IBaseRepository<Customer>> mockCustomerRepository;
        public AddNewCustomerTests()
        {
            mockCustomerRepository = RepositoryMocks.GetCustomerBaseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Handle_ValidCustomer_AddedToCustomerRepository()
        {
            //Arrange
            var handler = new AddNewCustomerHandler(mockCustomerRepository.Object, mapper);

            await handler.Handle(new AddNewCustomerCommand()
            {
                FirstName = "Thiru",
                LastName = "S",
                Email = "sthirumsc@gmail.com",
                DateOfBirth = Convert.ToDateTime("08-09-1990"),
                MobileNumber = "9677377507"
            }, CancellationToken.None);
            // Act
            var allCustomers = await mockCustomerRepository.Object.ListAllAsync();
            // Assert
            allCustomers.Count.ShouldBe(3);
        }
    }
}