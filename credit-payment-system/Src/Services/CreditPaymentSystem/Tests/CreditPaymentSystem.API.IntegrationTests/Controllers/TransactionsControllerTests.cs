using Newtonsoft.Json;
using CreditPaymentSystem.API.IntegrationTests.Base;
using CreditPaymentSystem.Application.Features.Purchase.Queries.GetOutstandingTransactionsList;
using System.Threading.Tasks;
using Xunit;

namespace CreditPaymentSystem.API.IntegrationTests.Controllers
{
    public class TransactionsControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public TransactionsControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task GetAllCustomersReturnsSuccessResult()
        {
            var client = factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/Transactions/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PagedOutstandingTransactionsListVm>(responseString);

            Assert.IsType<PagedOutstandingTransactionsListVm>(result);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task TotalOutstandingAmountReturnsSuccessResult()
        {
            var client = factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/Transactions/TotalOutstandingAmount");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PagedOutstandingTransactionsListVm>(responseString);

            Assert.IsType<PagedOutstandingTransactionsListVm>(result);

            Assert.NotNull(result);
        }
    }
}
