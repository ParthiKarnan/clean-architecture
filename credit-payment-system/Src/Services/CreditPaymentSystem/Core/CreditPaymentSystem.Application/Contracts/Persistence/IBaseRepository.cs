using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditPaymentSystem.Application.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
