using FluentValidation;
using SocieteGenerale.Application.Contracts.Persistence;
using SocieteGenerale.Domain.Common;
using System;

namespace SocieteGenerale.Application.Features.Payments.Commands.Payment
{
    public class PaymentValidator : AbstractValidator<PaymentCommand>
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly ICustomerRepository customerRepository;

        public PaymentValidator(ITransactionRepository transactionRepository, ICustomerRepository customerRepository)
        {
            RuleFor(p => p.CustomerId)
              .NotEmpty().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME)
              .NotNull();

            RuleFor(command => command.CustomerId)
                    .MustAsync((customerId, _) => (customerRepository.FindById(customerId)))
                    .WithMessage(ErrorMessage.VALIDATE_PROPERTY_DOESNOT_EXIST);

            RuleFor(p => p.TransactionId)
               .NotNull().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME);

            RuleFor(command => command.TransactionId)
               .MustAsync((transactionId, _) => (transactionRepository.FindById(transactionId)))
               .WithMessage(ErrorMessage.VALIDATE_PROPERTY_DOESNOT_EXIST);

            When(command => command.TransactionId != Guid.Empty, () =>
              {
                  RuleFor(command => command.TransactionId)
                   .MustAsync((command, transactionId, _) => (transactionRepository.CheckPendingTransactionsByCustomerIdAsync(command.CustomerId, command.TransactionId)))
                   .WithMessage(ErrorMessage.VALIDATE_CHECKPENDING_TRANSACTIONS_BY_CUSTOMERID);
              });

            RuleFor(p => p.Amout)
               .NotNull().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME);

            RuleFor(command => command.Amout)
                .MustAsync((command, transactionId, _) => (transactionRepository.CheckValidAmountByTransactionIdAsync(command.Amout, command.TransactionId)))
                .WithMessage(ErrorMessage.VALIDATE_CORRECT_OUTSTANDING_AMOUNT);

            this.transactionRepository = transactionRepository;
            this.customerRepository = customerRepository;
        }
    }
}