using CreditPaymentSystem.Application.Features.Purchase.Queries.GetOutstandingTransactionsList;
using CreditPaymentSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CreditPaymentSystem.Application.Contracts.Persistence
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<bool> FindById(Guid transactionId);
        Task<bool> CheckPendingTransactionsByCustomerIdAsync(Guid customerId, Guid transactionId);
        Task<PagedOutstandingTransactionsListVm> GetOutStandingTransactionsByCustomerIdAsync(Guid customerId);
        Task<bool> CheckValidAmountByTransactionIdAsync(decimal amount, Guid transactionId);
        Task<decimal> GetTotalOutStandingTransactionsAmountByCustomerIdAsync(Guid customerId);
    }
}