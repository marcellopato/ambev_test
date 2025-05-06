using System;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; private set; }
        public Guid SaleId { get; private set; }
        public Sale Sale { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmount { get; private set; }

        protected SaleItem() { }

        public SaleItem(Sale sale, string productName, int quantity, decimal unitPrice, decimal discount)
        {
            Id = Guid.NewGuid();
            Sale = sale;
            SaleId = sale.Id;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            var subtotal = Quantity * UnitPrice;
            TotalAmount = subtotal - (subtotal * Discount);
        }
    }
}
