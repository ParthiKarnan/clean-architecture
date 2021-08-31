using MediatR;
using System;

namespace SocieteGenerale.Application.Features.AccountSummary.Quries.GetTotalOutstandingAmount
{
    public class GetTotalOutstandingAmountQuery : IRequest<TotalOutstandingAmountVm>
    {
        public Guid CustomerId { get; set; }
    }
}
