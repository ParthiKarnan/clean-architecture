using CreditPaymentSystem.Domain.Common;
using System;

namespace CreditPaymentSystem.Domain.Entities
{
    public class Transaction : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; } 
        public bool IsPaid { get; set; }
        public Customer Customers { get; set; }        
    }
}