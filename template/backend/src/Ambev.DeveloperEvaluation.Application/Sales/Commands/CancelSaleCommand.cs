using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    public class CancelSaleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, bool>
    {
        public async Task<bool> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implementar persistência
            // Por enquanto retorna sucesso
            return true;
        }
    }
}
