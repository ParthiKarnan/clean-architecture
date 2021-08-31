using SocieteGenerale.Application.Responses;

namespace SocieteGenerale.Application.Features.Purchases.Commands.Purchase
{
    public class PurchaseResponse : BaseResponse
    {
        public PurchaseResponse() : base()
        {

        }
        public PurchaseDto Transaction { get; set; }
    }
}