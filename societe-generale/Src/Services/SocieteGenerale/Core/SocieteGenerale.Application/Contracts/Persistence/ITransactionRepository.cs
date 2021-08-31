using SocieteGenerale.Application.Features.Purchase.Queries.GetOutstandingTransactionsList;
using SocieteGenerale.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SocieteGenerale.Application.Contracts.Persistence
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