using MediatR;
using System;

namespace CreditPaymentSystem.Application.Features.Payments.Commands.Payment
{
    public class PaymentCommand : IRequest<PaymentResponse>
    {        
        public Guid CustomerId { get; set; }
        public Guid TransactionId { get; set; }
        public decimal Amout { get; set; }
    }
}