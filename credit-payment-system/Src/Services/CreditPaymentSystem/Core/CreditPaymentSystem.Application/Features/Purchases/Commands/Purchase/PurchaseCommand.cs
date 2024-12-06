using MediatR;
using System;
using static CreditPaymentSystem.Domain.Common.Enums;

namespace CreditPaymentSystem.Application.Features.Purchases.Commands.Purchase
{
    public class PurchaseCommand : IRequest<PurchaseResponse>
    {  
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}