using AutoMapper;
using SocieteGenerale.Application.Features.Customers.Commands.AddNewCustomer;
using SocieteGenerale.Application.Features.Customers.Queries.GetCustomersList;
using SocieteGenerale.Application.Features.Payments.Commands.Payment;
using SocieteGenerale.Application.Features.Purchases.Commands.Purchase;
using SocieteGenerale.Domain.Entities;

namespace SocieteGenerale.Application.Profiles
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