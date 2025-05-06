using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries
{
    public class GetSaleQuery : IRequest<SaleResponse>
    {
        public Guid Id { get; set; }
    }

    public class SaleResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CustomerName { get; set; }
        public string BranchName { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItemResponse> Items { get; set; }
    }

    public class SaleItemResponse
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
