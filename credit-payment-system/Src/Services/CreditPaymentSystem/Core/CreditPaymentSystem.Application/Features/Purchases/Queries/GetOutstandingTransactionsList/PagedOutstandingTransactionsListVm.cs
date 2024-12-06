using System;
using System.Collections.Generic;

namespace CreditPaymentSystem.Application.Features.Purchase.Queries.GetOutstandingTransactionsList
{
    public class PagedOutstandingTransactionsListVm
    {
        public int Count { get; set; }
        public decimal TotalOutstandingAmountWithIntrest { get; set; }
        public ICollection<OutstandingTransactionsListVm> OutstandingAmountListVm { get; set; }
    }
}