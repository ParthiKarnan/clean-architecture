using AutoMapper;
using MediatR;
using SocieteGenerale.Application.Contracts.Persistence;
using SocieteGenerale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocieteGenerale.Application.Features.Purchases.Commands.Purchase
{
    public class PurchaseHandler : IRequestHandler<PurchaseCommand, PurchaseResponse>
    {
        private readonly IBaseRepository<Transaction> baseRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        public PurchaseHandler(IBaseRepository<Transaction> baseRepository, IMapper mapper, ICustomerRepository customerRepository)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }
        public async Task<PurchaseResponse> Handle(PurchaseCommand request, CancellationToken cancellationToken)
        {
            var customerCommandResponse = new PurchaseResponse();
            var validator = new PurchaseValidator(customerRepository);
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
                var transaction = new Transaction()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = request.CustomerId,
                    Description = request.Description,
                    Amount = request.Amount,
                    IsPaid = false,
                    CreatedDate = DateTime.Now
                };
                transaction = await baseRepository.AddAsync(transaction);
                customerCommandResponse.Transaction = mapper.Map<PurchaseDto>(transaction);
            }
            return customerCommandResponse;
        }
    }
}