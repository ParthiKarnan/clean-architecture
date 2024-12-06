using MediatR;
using System;

namespace CreditPaymentSystem.Application.Features.AccountSummary.Quries.GetTotalOutstandingAmount
{
    public class GetTotalOutstandingAmountQuery : IRequest<TotalOutstandingAmountVm>
    {
        public Guid CustomerId { get; set; }
    }
}
