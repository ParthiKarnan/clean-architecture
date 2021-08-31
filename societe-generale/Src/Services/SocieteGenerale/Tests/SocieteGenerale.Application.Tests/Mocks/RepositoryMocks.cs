using Moq;
using SocieteGenerale.Application.Contracts.Persistence;
using SocieteGenerale.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SocieteGenerale.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IBaseRepository<Customer>> GetCustomerBaseRepository()
        {
            var currentDate = DateTime.Now;
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                    FirstName = "Parthiban",
                    LastName = "K",
                    Email = "parthi@parthibank.com",
                    DateOfBirth = Convert.ToDateTime("08-06-1989"),
                    MobileNumber = "9677377505",
                    IsActive = true,
                    CreatedDate = currentDate
                },
                new Customer
                {
                    Id = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                    FirstName = "Mathiyalagan",
                    LastName = "R",
                    Email = "rmathimsc@gmail.com",
                    DateOfBirth = Convert.ToDateTime("07-10-1991"),
                    MobileNumber = "9677377506",
                    IsActive = true,
                    CreatedDate = currentDate
                }
            };

            var mockCustomerRepository = new Mock<IBaseRepository<Customer>>();
            mockCustomerRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(customers);

            mockCustomerRepository.Setup(repo => repo.AddAsync(It.IsAny<Customer>())).ReturnsAsync(
                (Customer customer) =>
                {
                    customers.Add(customer);
                    return customer;
                });

            return mockCustomerRepository;
        }

        public static Mock<IBaseRepository<Transaction>> GetTransactionsRepository()
        {
            var currentDate = DateTime.Now;
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                    CreatedDate = currentDate,
                    Description = "Account Opened!",
                    Amount = 0,
                    IsPaid = true
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                    CreatedDate = currentDate.AddDays(-2),
                    Description = "Account Opened!",
                    Amount = 100,
                    IsPaid = false
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                    CreatedDate = currentDate.AddDays(-14),
                    Description = "Account Opened!",
                    Amount = 200,
                    IsPaid = false
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                    CreatedDate = currentDate.AddDays(-30),
                    Description = "Account Opened!",
                    Amount = 300,
                    IsPaid = false
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                    CreatedDate = currentDate.AddDays(-60),
                    Description = "Account Opened!",
                    Amount = 400,
                    IsPaid = false
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                    CreatedDate = currentDate.AddDays(-180),
                    Description = "Account Opened!",
                    Amount = 500,
                    IsPaid = false
                },

                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                    CreatedDate = currentDate,
                    Description = "Account Opened!",
                    Amount = 0,
                    IsPaid = true
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                    CreatedDate = currentDate.AddDays(-2),
                    Description = "Account Opened!",
                    Amount = 100,
                    IsPaid = false
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                    CreatedDate = currentDate.AddDays(-14),
                    Description = "Account Opened!",
                    Amount = 200,
                    IsPaid = false
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                    CreatedDate = currentDate.AddDays(-30),
                    Description = "Account Opened!",
                    Amount = 300,
                    IsPaid = false
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                    CreatedDate = currentDate.AddDays(-60),
                    Description = "Account Opened!",
                    Amount = 400,
                    IsPaid = false
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                    CreatedDate = currentDate.AddDays(-180),
                    Description = "Account Opened!",
                    Amount = 500,
                    IsPaid = false
                },
            };

            var mockCustomerRepository = new Mock<IBaseRepository<Transaction>>();
            mockCustomerRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(transactions);

            mockCustomerRepository.Setup(repo => repo.AddAsync(It.IsAny<Transaction>())).ReturnsAsync(
                (Transaction transaction) =>
                {
                    transactions.Add(transaction);
                    return transaction;
                });

            return mockCustomerRepository;
        }
    }
}