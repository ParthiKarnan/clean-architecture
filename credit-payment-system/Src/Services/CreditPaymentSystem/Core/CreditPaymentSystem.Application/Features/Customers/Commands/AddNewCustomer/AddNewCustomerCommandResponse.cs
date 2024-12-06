using CreditPaymentSystem.Application.Responses;

namespace CreditPaymentSystem.Application.Features.Customers.Commands.AddNewCustomer
{
    public class AddNewCustomerCommandResponse : BaseResponse
    {
        public AddNewCustomerCommandResponse() : base()
        {

        }
        public CustomerDto Customer { get; set; }
    }
}