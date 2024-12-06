using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CreditPaymentSystem.Application.Contracts.Persistence;
using CreditPaymentSystem.Persistence.Repositories;

namespace CreditPaymentSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CreditPaymentSystemDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("CreditPaymentSystemPaymentManagement"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}