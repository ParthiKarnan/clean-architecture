using System;

namespace CreditPaymentSystem.Application.Features.Purchase.Queries.GetOutstandingTransactionsList
{
    public class OutstandingTransactionsListVm
    {
        public Guid TransactionId { get; set; }
        public string Description { get; set; }
        public DateTime PurchasedDate { get; set; }
        public decimal PurchasedAmount { get; set; }
        public decimal OutstandingAmountWithInterest { get; set; }
    }
}