﻿using Newtonsoft.Json;
using CreditPaymentSystem.API.IntegrationTests.Base;
using CreditPaymentSystem.Application.Features.Customers.Queries.GetCustomersList;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CreditPaymentSystem.API.IntegrationTests.Controllers
{
    public class CustomersControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public CustomersControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task GetAllCustomersReturnsSuccessResult()
        {
            var client = factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/Customers/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<CustomersListVm>>(responseString);

            Assert.IsType<List<CustomersListVm>>(result);

            Assert.NotEmpty(result);
        }
    }
}