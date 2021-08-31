using AutoMapper;
using MediatR;
using SocieteGenerale.Application.Contracts.Persistence;
using SocieteGenerale.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocieteGenerale.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomersListVm>>
    {
        private readonly IBaseRepository<Customer> customerRepository;
        private readonly IMapper mapper;
        public GetCustomersListQueryHandler(IBaseRepository<Customer> customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }
        public async Task<List<CustomersListVm>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = (await customerRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return mapper.Map<List<CustomersListVm>>(allCustomers);
        }
    }
}