using AutoMapper;
using MediatR;
using CreditPaymentSystem.Application.Contracts.Persistence;
using CreditPaymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CreditPaymentSystem.Application.Features.Customers.Commands.AddNewCustomer
{
    public class AddNewCustomerHandler : IRequestHandler<AddNewCustomerCommand, AddNewCustomerCommandResponse>
    {
        private readonly IBaseRepository<Customer> customerRepository;
        private readonly IMapper mapper;
        public AddNewCustomerHandler(IBaseRepository<Customer> customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }
        public async Task<AddNewCustomerCommandResponse> Handle(AddNewCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerCommandResponse = new AddNewCustomerCommandResponse();
            var validator = new AddNewCustomerValidator();
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
                var currentDate = DateTime.Now;

                var customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    MobileNumber = request.MobileNumber,
                    DateOfBirth = request.DateOfBirth,
                    CreatedDate = currentDate,
                    IsActive = true
                };
                customer = await customerRepository.AddAsync(customer);
                customerCommandResponse.Customer = mapper.Map<CustomerDto>(customer);
            }
            return customerCommandResponse;
        }
    }
}
