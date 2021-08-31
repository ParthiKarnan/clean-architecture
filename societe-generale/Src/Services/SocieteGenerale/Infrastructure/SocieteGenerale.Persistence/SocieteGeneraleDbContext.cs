using Microsoft.EntityFrameworkCore;
using SocieteGenerale.Domain.Common;
using SocieteGenerale.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocieteGenerale.Persistence
{
    public class SocieteGeneraleDbContext : DbContext
    {
        public SocieteGeneraleDbContext(DbContextOptions<SocieteGeneraleDbContext> options)
           : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocieteGeneraleDbContext).Assembly);

            //seed data, added through migrations
            var currentDate = DateTime.Now;

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                FirstName = "Parthiban",
                LastName = "K",
                Email = "parthi@parthibank.com",
                DateOfBirth = Convert.ToDateTime("08-06-1989"),
                MobileNumber = "9677377505",
                IsActive = true,
                CreatedDate = currentDate
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                FirstName = "Mathiyalagan",
                LastName = "R",
                Email = "rmathimsc@gmail.com",
                DateOfBirth = Convert.ToDateTime("07-10-1991"),
                MobileNumber = "9677377506",
                IsActive = true,
                CreatedDate = currentDate
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate,
                Description = "Account Opened!",
                Amount = 0,
                IsPaid = true
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-2),
                Description = "Online shopping!",
                Amount = 100,
                IsPaid = false
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-14),
                Description = "Online shopping!",
                Amount = 200,
                IsPaid = false
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-30),
                Description = "Online shopping!",
                Amount = 300,
                IsPaid = false
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-60),
                Description = "Online shopping!",
                Amount = 400,
                IsPaid = false
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{5DC6D320-AED8-415C-B4C7-870626FE2C2C}"),
                CreatedDate = currentDate.AddDays(-180),
                Description = "Online shopping!",
                Amount = 500,
                IsPaid = false
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate,
                Description = "Account Opened!",
                Amount = 0,
                IsPaid = true
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-2),
                Description = "Online shopping!",
                Amount = 100,
                IsPaid = false
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-14),
                Description = "Online shopping!",
                Amount = 200,
                IsPaid = false
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-30),
                Description = "Account Opened!",
                Amount = 300,
                IsPaid = false
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-60),
                Description = "Online shopping!",
                Amount = 400,
                IsPaid = false
            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse("{D06497BE-1F09-47A8-8773-05D2FEA15E51}"),
                CreatedDate = currentDate.AddDays(-180),
                Description = "Online shopping!",
                Amount = 500,
                IsPaid = false
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
