using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public class CreateSaleCommand : IRequest<CreateSaleResponse>
    {
        public string CustomerName { get; set; }
        public string BranchName { get; set; }
        public List<SaleItemCommand> Items { get; set; }
    }

    public class SaleItemCommand
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class CreateSaleResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
