using CreditPaymentSystem.Application.Responses;

namespace CreditPaymentSystem.Application.Features.Purchases.Commands.Purchase
{
    public class PurchaseResponse : BaseResponse
    {
        public PurchaseResponse() : base()
        {

        }
        public PurchaseDto Transaction { get; set; }
    }
}