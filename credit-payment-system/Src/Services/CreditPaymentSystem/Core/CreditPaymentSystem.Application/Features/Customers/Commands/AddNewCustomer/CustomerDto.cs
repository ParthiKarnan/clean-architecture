using System;

namespace CreditPaymentSystem.Application.Features.Customers.Commands.AddNewCustomer
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
    }
}