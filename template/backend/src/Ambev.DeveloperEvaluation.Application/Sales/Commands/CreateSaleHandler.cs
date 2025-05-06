using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResponse>
    {
        private readonly ISaleRepository _repository;

        public CreateSaleHandler(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateSaleResponse> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale(request.CustomerName, request.BranchName);
            
            foreach(var item in request.Items)
            {
                sale.AddItem(item.ProductName, item.Quantity, item.UnitPrice);
            }

            await _repository.AddAsync(sale);

            return new CreateSaleResponse 
            { 
                Id = sale.Id,
                Number = sale.Number,
                TotalAmount = sale.TotalAmount
            };
        }
    }
}
