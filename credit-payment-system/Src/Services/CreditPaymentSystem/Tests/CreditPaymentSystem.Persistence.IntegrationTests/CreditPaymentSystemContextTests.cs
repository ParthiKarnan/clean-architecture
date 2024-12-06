using Microsoft.EntityFrameworkCore;
using Shouldly;
using CreditPaymentSystem.Domain.Entities;
using System;
using Xunit;

namespace CreditPaymentSystem.Persistence.IntegrationTests
{
    public class CreditPaymentSystemContextTests
    {
        private readonly CreditPaymentSystemDbContext CreditPaymentSystemDbContext;

        public CreditPaymentSystemContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<CreditPaymentSystemDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            this.CreditPaymentSystemDbContext = new CreditPaymentSystemDbContext(dbContextOptions);
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
            CreditPaymentSystemDbContext.Customers.Add(customer);
            await CreditPaymentSystemDbContext.SaveChangesAsync();
            var result = CreditPaymentSystemDbContext.Customers.FirstOrDefaultAsync(s => s.Id == Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"));
            // Assert
            result.Result.Id.ToString().ShouldBe(customer.Id.ToString());
        }
    }
}
