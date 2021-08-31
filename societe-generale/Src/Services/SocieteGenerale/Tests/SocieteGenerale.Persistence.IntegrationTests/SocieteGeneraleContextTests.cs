using Microsoft.EntityFrameworkCore;
using Shouldly;
using SocieteGenerale.Domain.Entities;
using System;
using Xunit;

namespace SocieteGenerale.Persistence.IntegrationTests
{
    public class SocieteGeneraleContextTests
    {
        private readonly SocieteGeneraleDbContext societeGeneraleDbContext;

        public SocieteGeneraleContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<SocieteGeneraleDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            this.societeGeneraleDbContext = new SocieteGeneraleDbContext(dbContextOptions);
        }
        [Fact]
        public async void Save_NewCustomer()
        {
            var currentDate = DateTime.Now;
            // Assert
            var customer = new Customer()
            {
                Id = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                FirstName = "Parthiban",
                LastName = "K",
                Email = "parthi@parthibank.com",
                DateOfBirth = Convert.ToDateTime("08-06-1989"),
                MobileNumber = "9677377505",
                IsActive = true,
                CreatedDate = currentDate
            };
            // Act
            societeGeneraleDbContext.Customers.Add(customer);
            await societeGeneraleDbContext.SaveChangesAsync();
            var result = societeGeneraleDbContext.Customers.FirstOrDefaultAsync(s => s.Id == Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"));
            // Assert
            result.Result.Id.ToString().ShouldBe(customer.Id.ToString());
        }
    }
}
