using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries
{
    public class GetAllSalesQuery : IRequest<List<SaleSummaryResponse>> { }

    public class SaleSummaryResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }
}
