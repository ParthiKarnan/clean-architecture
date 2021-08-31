using MediatR;
using SocieteGenerale.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SocieteGenerale.Application.Features.Purchase.Queries.GetOutstandingTransactionsList
{
    public class GetOutstandingTransactionsListHandler : IRequestHandler<GetOutstandingTransactionsListQuery, PagedOutstandingTransactionsListVm>
    {
        private readonly ITransactionRepository transactionRepository;
        public GetOutstandingTransactionsListHandler(ITransactionRepository transactionRepository)
        {

            this.transactionRepository = transactionRepository;
        }
        public async Task<PagedOutstandingTransactionsListVm> Handle(GetOutstandingTransactionsListQuery request, CancellationToken cancellationToken)
        {
            return await transactionRepository.GetOutStandingTransactionsByCustomerIdAsync(request.CustomerId);
        }
    }
}