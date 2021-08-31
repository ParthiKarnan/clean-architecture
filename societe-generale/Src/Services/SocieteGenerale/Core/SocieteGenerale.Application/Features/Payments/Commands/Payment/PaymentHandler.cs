using AutoMapper;
using MediatR;
using SocieteGenerale.Application.Contracts.Persistence;
using SocieteGenerale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocieteGenerale.Application.Features.Payments.Commands.Payment
{
    public class PaymentHandler : IRequestHandler<PaymentCommand, PaymentResponse>
    {
        private readonly IBaseRepository<Transaction> baseRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ITransactionRepository transactionRepository;

        private readonly IMapper mapper;
        public PaymentHandler(IBaseRepository<Transaction> baseRepository, IMapper mapper, ICustomerRepository customerRepository, ITransactionRepository transactionRepository)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.customerRepository = customerRepository;
            this.transactionRepository = transactionRepository;
        }
        public async Task<PaymentResponse> Handle(PaymentCommand request, CancellationToken cancellationToken)
        {
            var customerCommandResponse = new PaymentResponse();
            var validator = new PaymentValidator(transactionRepository,customerRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                customerCommandResponse.Success = false;
                customerCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    customerCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (customerCommandResponse.Success)
            {
                var transaction = await baseRepository.GetByIdAsync(request.TransactionId);
                if (transaction != null)
                {
                    transaction.IsPaid = true;
                    transaction.LastModifiedDate = DateTime.Now;
                    await baseRepository.UpdateAsync(transaction);
                    customerCommandResponse.Payment = mapper.Map<PaymentDto>(transaction);
                }                
            }
            return customerCommandResponse;
        }
    }
}