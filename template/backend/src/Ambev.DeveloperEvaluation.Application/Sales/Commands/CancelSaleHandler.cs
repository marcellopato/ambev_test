public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public CancelSaleHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _context.Sales.FindAsync(request.Id);
        if (sale == null) return false;

        sale.Cancel();
        await _context.SaveChangesAsync();
        return true;
    }
}
