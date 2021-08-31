using MediatR;
using System;

namespace SocieteGenerale.Application.Features.Purchase.Queries.GetOutstandingTransactionsList
{
    public class GetOutstandingTransactionsListQuery : IRequest<PagedOutstandingTransactionsListVm>
    {
        public Guid CustomerId { get; set; }
    }
}
