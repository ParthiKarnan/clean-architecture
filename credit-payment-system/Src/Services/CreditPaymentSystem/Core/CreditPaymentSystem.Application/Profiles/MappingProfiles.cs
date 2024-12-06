using AutoMapper;
using CreditPaymentSystem.Application.Features.Customers.Commands.AddNewCustomer;
using CreditPaymentSystem.Application.Features.Customers.Queries.GetCustomersList;
using CreditPaymentSystem.Application.Features.Payments.Commands.Payment;
using CreditPaymentSystem.Application.Features.Purchases.Commands.Purchase;
using CreditPaymentSystem.Domain.Entities;

namespace CreditPaymentSystem.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Transaction, PurchaseDto>();
            CreateMap<Transaction, PaymentDto>();
            CreateMap<Customer, CustomersListVm>();
        }
    }
}