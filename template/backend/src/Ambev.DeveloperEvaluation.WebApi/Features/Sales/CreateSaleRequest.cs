namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    public class CreateSaleRequest
    {
        public string CustomerName { get; set; }
        public string BranchName { get; set; }
        public List<SaleItemRequest> Items { get; set; }
    }

    public class SaleItemRequest
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
