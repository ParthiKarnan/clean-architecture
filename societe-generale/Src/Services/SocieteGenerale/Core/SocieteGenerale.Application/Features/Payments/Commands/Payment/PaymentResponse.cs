using SocieteGenerale.Application.Responses;

namespace SocieteGenerale.Application.Features.Payments.Commands.Payment
{
    public class PaymentResponse : BaseResponse
    {
        public PaymentResponse() : base()
        {

        }
        public PaymentDto Payment { get; set; }
    }
}