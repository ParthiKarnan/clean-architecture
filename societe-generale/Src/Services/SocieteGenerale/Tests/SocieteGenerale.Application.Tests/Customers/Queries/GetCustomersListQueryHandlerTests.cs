using AutoMapper;
using Moq;
using Shouldly;
using SocieteGenerale.Application.Contracts.Persistence;
using SocieteGenerale.Application.Features.Customers.Queries.GetCustomersList;
using SocieteGenerale.Application.Profiles;
using SocieteGenerale.Application.UnitTests.Mocks;
using SocieteGenerale.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SocieteGenerale.Application.UnitTests.Customers.Queries
{

    public class GetCustomersListQueryHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IBaseRepository<Customer>> mockCustomerRepository;
        public GetCustomersListQueryHandlerTests()
        {
            mockCustomerRepository = RepositoryMocks.GetCustomerBaseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task GetCategoriesListTest()
        {
            // Arrange
            var handler = new GetCustomersListQueryHandler(mockCustomerRepository.Object, mapper);
            // Act
            var result = await handler.Handle(new GetCustomersListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CustomersListVm>>();
            // Assert
            result.Count.ShouldBe(2);
        }
    }
}
