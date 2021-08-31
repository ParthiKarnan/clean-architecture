using Microsoft.EntityFrameworkCore;
using SocieteGenerale.Application.Contracts.Persistence;
using SocieteGenerale.Application.Features.Purchase.Queries.GetOutstandingTransactionsList;
using SocieteGenerale.Domain.Common;
using SocieteGenerale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SocieteGenerale.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(SocieteGeneraleDbContext dbContext) : base(dbContext)
        {

        }
        /// <summary>
        /// Find by Id or Not
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public async Task<bool> FindById(Guid transactionId)
        {
            return await dbContext.Transactions.Where(x => x.Id == transactionId).AnyAsync();
        }
        /// <summary>
        /// Check Pending Transactions By Customer Id Or Not
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public async Task<bool> CheckPendingTransactionsByCustomerIdAsync(Guid customerId, Guid transactionId)
        {
            bool isValue = false;
            var transations = await dbContext.Transactions
                                    .Where(x => x.CustomerId == customerId && x.IsPaid == false)
                                    .Select(x => new
                                    {
                                        x.Id,
                                        x.CreatedDate
                                    }).OrderByDescending(s => s.CreatedDate).ToListAsync();
            var currentDate = DateTime.Now;
            if (transations.Where(s => s.CreatedDate.Date.Equals(currentDate.Date) && s.Id == transactionId).Any())
            {
                isValue = true;
            }
            else
            {
                var firstTransactionId = transations.OrderByDescending(s => s.CreatedDate).Select(s => s.Id).FirstOrDefault();
                if (firstTransactionId == transactionId)
                    isValue = true;
                else
                    isValue = false;
            }
            return isValue;
        }
        /// <summary>
        /// Check the given amount is correct or not againts the transaction Id
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public async Task<bool> CheckValidAmountByTransactionIdAsync(decimal amount, Guid transactionId)
        {
            var currentDate = DateTime.Now;
            var transaction = await dbContext.Transactions
                                    .Where(x => x.Id == transactionId && x.IsPaid == false)
                                    .Select(x => new
                                    {
                                        x.Amount,
                                        x.CreatedDate
                                    }).FirstOrDefaultAsync();
            decimal totalAmountWithInterestRate = currentDate.Date.Equals(transaction.CreatedDate.Date) ? transaction.Amount :
                                                  ExtensionHelper.RateOfInterestCalculationByAmountAndItsDuration(transaction.CreatedDate, transaction.Amount);
            if (amount == totalAmountWithInterestRate)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Get Total Outstanding Amount By Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<decimal> GetOutStandingCreditAmountByCustomerIdAsync(Guid customerId)
        {
            var totalOutstandingAmount = await dbContext.Transactions.Where(x => x.CustomerId == customerId && x.IsPaid == false)
                                                        .Select(x => x.Amount).SumAsync();
            return totalOutstandingAmount;
        }

        /// <summary>
        /// Get All Outstanding Transactions and its sum By Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<PagedOutstandingTransactionsListVm> GetOutStandingTransactionsByCustomerIdAsync(Guid customerId)
        {
            PagedOutstandingTransactionsListVm pagedOutstandingAmountListVm = new();
            var transations = await dbContext.Transactions
                                    .Where(x => x.CustomerId == customerId && x.IsPaid == false)
                                    .Select(x => new OutstandingTransactionsListVm
                                    {
                                        TransactionId = x.Id,
                                        Description = x.Description,
                                        PurchasedAmount = x.Amount,
                                        PurchasedDate = x.CreatedDate
                                    }).ToListAsync();

            List<OutstandingTransactionsListVm> transactionsWithInterest = ApplyRateOfInterestForEachTransaction(transations);
            pagedOutstandingAmountListVm.TotalOutstandingAmountWithIntrest = transactionsWithInterest.Sum(x => x.OutstandingAmountWithInterest);
            pagedOutstandingAmountListVm.OutstandingAmountListVm = transactionsWithInterest.OrderBy(x => x.PurchasedDate).ToList();
            pagedOutstandingAmountListVm.Count = transactionsWithInterest.Count;
            return pagedOutstandingAmountListVm;
        }
        /// <summary>
        /// Get Total Outstanding Transactions Amount By Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<decimal> GetTotalOutStandingTransactionsAmountByCustomerIdAsync(Guid customerId)
        {
            var transations = await dbContext.Transactions
                                    .Where(x => x.CustomerId == customerId && x.IsPaid == false)
                                    .Select(x => new OutstandingTransactionsListVm
                                    {
                                        TransactionId = x.Id,
                                        Description = x.Description,
                                        PurchasedAmount = x.Amount,
                                        PurchasedDate = x.CreatedDate
                                    }).ToListAsync();

            List<OutstandingTransactionsListVm> transactionsWithInterest = ApplyRateOfInterestForEachTransaction(transations);
            decimal TotalOutstandingAmountWithIntrest = transactionsWithInterest.Sum(x => x.OutstandingAmountWithInterest);
            return TotalOutstandingAmountWithIntrest;
        }
        /// <summary>
        /// Apply Rate Of Interest For Each Transaction Based the duration from invoice-date to current date
        /// (i) duration <= 14 days - 4 %
        /// (ii) duration > 14 days & <= 30 days - 6 %
        /// (iii) duration > 30 days & <= 60 days - 10 %
        /// (iv) duration > 60 days  & <= 180 days - 16 %
        /// (v) duration > 180 days - 20 %
        /// </summary>
        /// <param name="transations"></param>
        /// <returns> Rate of Interest Calculation With Each Transaction</returns>
        private static List<OutstandingTransactionsListVm> ApplyRateOfInterestForEachTransaction(List<OutstandingTransactionsListVm> transations)
        {
            var transactionsWithInterest = new List<OutstandingTransactionsListVm>();
            var currentDate = DateTime.Now;
            if (transations.Count > 0)
            {
                foreach (var transation in transations)
                {
                    decimal totalAmountWithInterestRate = currentDate.Date.Equals(transation.PurchasedDate.Date) ? transation.PurchasedAmount : ExtensionHelper.RateOfInterestCalculationByAmountAndItsDuration(transation.PurchasedDate, transation.PurchasedAmount);

                    OutstandingTransactionsListVm outstandingAmount = new()
                    {
                        TransactionId = transation.TransactionId,
                        Description = transation.Description,
                        PurchasedDate = transation.PurchasedDate,
                        PurchasedAmount = transation.PurchasedAmount,
                        OutstandingAmountWithInterest = totalAmountWithInterestRate
                    };
                    transactionsWithInterest.Add(outstandingAmount);
                }
            }
            return transactionsWithInterest;
        }
    }
}