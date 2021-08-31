using SocieteGenerale.Domain.Entities;
using SocieteGenerale.Persistence;
using System;

namespace SocieteGenerale.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(SocieteGeneraleDbContext context)
        {
            var currentDate = DateTime.Now;

            context.Customers.Add(new Customer
            {
                Id = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                FirstName = "Parthiban",
                LastName = "K",
                Email = "parthi@parthibank.com",
                DateOfBirth = Convert.ToDateTime("08-06-1989"),
                MobileNumber = "9677377505",
                IsActive = true,
                CreatedDate = currentDate
            });

            context.Customers.Add(new Customer
            {
                Id = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                FirstName = "Mathiyalagan",
                LastName = "R",
                Email = "rmathimsc@gmail.com",
                DateOfBirth = Convert.ToDateTime("07-10-1991"),
                MobileNumber = "9677377506",
                IsActive = true,
                CreatedDate = currentDate
            });

            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate,
                Description = "Account Opened!",
                Amount = 0,
                IsPaid = true
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-2),
                Description = "Account Opened!",
                Amount = 100,
                IsPaid = false
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-14),
                Description = "Account Opened!",
                Amount = 200,
                IsPaid = false
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-30),
                Description = "Account Opened!",
                Amount = 300,
                IsPaid = false
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-60),
                Description = "Account Opened!",
                Amount = 400,
                IsPaid = false
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-180),
                Description = "Account Opened!",
                Amount = 500,
                IsPaid = false
            });

            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate,
                Description = "Account Opened!",
                Amount = 0,
                IsPaid = true
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-2),
                Description = "Account Opened!",
                Amount = 100,
                IsPaid = false
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-14),
                Description = "Account Opened!",
                Amount = 200,
                IsPaid = false
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-30),
                Description = "Account Opened!",
                Amount = 300,
                IsPaid = false
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-60),
                Description = "Account Opened!",
                Amount = 400,
                IsPaid = false
            });
            context.Transactions.Add(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-180),
                Description = "Account Opened!",
                Amount = 500,
                IsPaid = false
            });

            context.SaveChanges();
        }
    }
}
