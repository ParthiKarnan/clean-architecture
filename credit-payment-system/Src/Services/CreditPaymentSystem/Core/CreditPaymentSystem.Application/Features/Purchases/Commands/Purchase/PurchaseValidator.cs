using FluentValidation;
using CreditPaymentSystem.Application.Contracts.Persistence;
using CreditPaymentSystem.Domain.Common;
using System;
using static CreditPaymentSystem.Domain.Common.Enums;

namespace CreditPaymentSystem.Application.Features.Purchases.Commands.Purchase
{
    public class PurchaseValidator : AbstractValidator<PurchaseCommand>
    {
        private readonly ICustomerRepository customerRepository;
        public PurchaseValidator(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;

            RuleFor(p => p.CustomerId)
               .NotEmpty().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME)
               .NotNull();
            
            RuleFor(command => command.CustomerId)
                    .MustAsync((customerId, _) => (customerRepository.FindById(customerId)))
                    .WithMessage(ErrorMessage.VALIDATE_PROPERTY_DOESNOT_EXIST);

            RuleFor(p => p.Description)
               .NotEmpty().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME)
               .NotNull();

            RuleFor(p => p.Amount)
                    .NotNull().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME);
            
            RuleFor(p => p.PaymentType).NotEmpty().IsInEnum();

            When(command => ((int)command.PaymentType).Equals((int)PaymentType.Credit), () =>
            {
                RuleFor(command => command.CustomerId).NotEmpty()
                       .MustAsync((customerId, _) => customerRepository.IsLongTermCustomerByIdAsync(customerId))
                       .When(c => c.CustomerId != Guid.Empty)
                       .WithMessage(ErrorMessage.VALIDATE_LONGTERM_CUSTOMER_BY_ID);
            });   
        }
    }
}