using MediatR;
using System.Collections.Generic;

namespace SocieteGenerale.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<CustomersListVm>>
    {
    }
}
