using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditPaymentSystem.Application.Features.Customers.Commands.AddNewCustomer;
using CreditPaymentSystem.Application.Features.Customers.Queries.GetCustomersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditPaymentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("all", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CustomersListVm>>> GetAllCustomers()
        {
            var dtos = await mediator.Send(new GetCustomersListQuery());
            return Ok(dtos);
        }
        [HttpPost]
        public async Task<ActionResult<AddNewCustomerCommandResponse>> AddCustomer([FromBody] AddNewCustomerCommand addNewCustomerCommand)
        {
            var response = await mediator.Send(addNewCustomerCommand);
            return Ok(response);
        }
    }
}