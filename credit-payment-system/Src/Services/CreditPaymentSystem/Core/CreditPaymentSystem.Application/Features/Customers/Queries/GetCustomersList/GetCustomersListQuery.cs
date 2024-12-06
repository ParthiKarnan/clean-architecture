using MediatR;
using System.Collections.Generic;

namespace CreditPaymentSystem.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<CustomersListVm>>
    {
    }
}
