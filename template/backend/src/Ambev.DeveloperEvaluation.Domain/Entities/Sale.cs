using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public string Number { get; private set; }
        public DateTime Date { get; private set; }
        public string CustomerName { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string BranchName { get; private set; }
        public bool IsCancelled { get; private set; }
        public ICollection<SaleItem> Items { get; private set; }

        protected Sale() { }

        public Sale(string customerName, string branchName)
        {
            Id = Guid.NewGuid();
            Number = DateTime.Now.ToString("yyyyMMddHHmmss");
            Date = DateTime.Now;
            CustomerName = customerName;
            BranchName = branchName;
            Items = new List<SaleItem>();
            IsCancelled = false;
        }

        public void AddItem(string productName, int quantity, decimal unitPrice)
        {
            if (quantity > 20)
                throw new InvalidOperationException("Não é permitido vender mais de 20 itens idênticos");

            var discount = CalculateDiscount(quantity);
            var item = new SaleItem(this, productName, quantity, unitPrice, discount);
            Items.Add(item);
            UpdateTotalAmount();
        }

        private decimal CalculateDiscount(int quantity)
        {
            if (quantity < 4) return 0;
            if (quantity >= 10 && quantity <= 20) return 0.20m;
            return 0.10m;
        }

        private void UpdateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var item in Items)
            {
                TotalAmount += item.TotalAmount;
            }
        }

        public void Cancel()
        {
            IsCancelled = true;
            // Aqui poderíamos publicar um evento SaleCancelled
        }
    }
}
