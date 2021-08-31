using MediatR;
using System;
using static SocieteGenerale.Domain.Common.Enums;

namespace SocieteGenerale.Application.Features.Purchases.Commands.Purchase
{
    public class PurchaseCommand : IRequest<PurchaseResponse>
    {  
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}