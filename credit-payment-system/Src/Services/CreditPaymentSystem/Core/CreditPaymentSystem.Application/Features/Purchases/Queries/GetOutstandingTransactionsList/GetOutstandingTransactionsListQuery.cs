using MediatR;
using System;

namespace CreditPaymentSystem.Application.Features.Purchase.Queries.GetOutstandingTransactionsList
{
    public class GetOutstandingTransactionsListQuery : IRequest<PagedOutstandingTransactionsListVm>
    {
        public Guid CustomerId { get; set; }
    }
}
