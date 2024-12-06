using Microsoft.EntityFrameworkCore;
using CreditPaymentSystem.Application.Contracts.Persistence;
using CreditPaymentSystem.Domain.Common;
using CreditPaymentSystem.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CreditPaymentSystem.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CreditPaymentSystemDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// Find by Id or Not
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<bool> FindById(Guid customerId)
        {
            return await dbContext.Customers.Where(x => x.Id == customerId).AnyAsync();
        }
        /// <summary>
        /// Check the given customer Id is a Long-term customer or not
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<bool> IsLongTermCustomerByIdAsync(Guid customerId)
        {
            var createdDate = await dbContext.Customers.Where(x => x.Id == customerId)
                                                       .AsNoTracking().Select(x => x.CreatedDate).FirstOrDefaultAsync();
            var currentDate = DateTime.Now;
            var months = ExtensionHelper.GetMonthDifference(currentDate, createdDate);
            if (months > 24)
                return true;
            else
                return false;
        }
    }
}