using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResponse>
    {
        public async Task<CreateSaleResponse> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale(request.CustomerName, request.BranchName);
            
            foreach(var item in request.Items)
            {
                sale.AddItem(item.ProductName, item.Quantity, item.UnitPrice);
            }

            // TODO: Adicionar persistência
            
            return new CreateSaleResponse 
            { 
                Id = sale.Id,
                Number = sale.Number,
                TotalAmount = sale.TotalAmount
            };
        }
    }
}
