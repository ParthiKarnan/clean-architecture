using CreditPaymentSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CreditPaymentSystem.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<bool> IsLongTermCustomerByIdAsync(Guid customerId);
        Task<bool> FindById(Guid customerId);
    }
}
