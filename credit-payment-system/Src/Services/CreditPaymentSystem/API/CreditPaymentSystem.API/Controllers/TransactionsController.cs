using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditPaymentSystem.Application.Features.AccountSummary.Quries.GetTotalOutstandingAmount;
using CreditPaymentSystem.Application.Features.Payments.Commands.Payment;
using CreditPaymentSystem.Application.Features.Purchase.Queries.GetOutstandingTransactionsList;
using CreditPaymentSystem.Application.Features.Purchases.Commands.Purchase;
using System.Threading.Tasks;

namespace CreditPaymentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransactionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllOutstandingTransactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedOutstandingTransactionsListVm>> GetAllOutstandingTransactions([FromQuery] GetOutstandingTransactionsListQuery query)
        {
            var dtos = await mediator.Send(query);
            return Ok(dtos);
        }
        [HttpGet("TotalOutstandingAmount", Name = "GetTotalOutstandingAmount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TotalOutstandingAmountVm>> GetTotalOutstandingAmount([FromQuery] GetTotalOutstandingAmountQuery query)
        {
            var dtos = await mediator.Send(query);
            return Ok(dtos);
        }
        [HttpPost("Purchase")]
        public async Task<ActionResult<PurchaseResponse>> Purchase([FromBody] PurchaseCommand purchaseCommand)
        {
            var response = await mediator.Send(purchaseCommand);
            return Ok(response);
        }
        [HttpPost("Payment")]
        public async Task<ActionResult<PaymentResponse>> MakePayment([FromBody] PaymentCommand paymentCommand)
        {
            var response = await mediator.Send(paymentCommand);
            return Ok(response);
        }
    }
}
