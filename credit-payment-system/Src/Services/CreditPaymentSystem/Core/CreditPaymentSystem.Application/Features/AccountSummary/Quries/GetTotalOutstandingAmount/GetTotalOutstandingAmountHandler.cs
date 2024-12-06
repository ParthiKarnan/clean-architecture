using MediatR;
using CreditPaymentSystem.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace CreditPaymentSystem.Application.Features.AccountSummary.Quries.GetTotalOutstandingAmount
{
    public class GetTotalOutstandingAmountHandler : IRequestHandler<GetTotalOutstandingAmountQuery, TotalOutstandingAmountVm>
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTotalOutstandingAmountHandler(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public async Task<TotalOutstandingAmountVm> Handle(GetTotalOutstandingAmountQuery request, CancellationToken cancellationToken)
        {
            return new TotalOutstandingAmountVm
            {
                OutstandingCreditAmount = await transactionRepository.GetTotalOutStandingTransactionsAmountByCustomerIdAsync(request.CustomerId)
            };
        }
    }}