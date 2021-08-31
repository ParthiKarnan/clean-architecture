﻿using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocieteGenerale.Application.Features.Customers.Commands.AddNewCustomer
{
    public class AddNewCustomerCommand : IRequest<AddNewCustomerCommandResponse>
    {
        private DateTime birthDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth
        {
            get { return birthDate; }
            set { birthDate = value.Date; }
        }
        public string MobileNumber { get; set; }
    }
}