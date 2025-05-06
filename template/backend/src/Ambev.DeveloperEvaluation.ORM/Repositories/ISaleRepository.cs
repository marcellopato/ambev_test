using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(Guid id);
        Task<List<Sale>> GetAllAsync();
        Task<Sale> AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task<Sale> GetByNumberAsync(string number);
        Task<List<Sale>> GetByCustomerNameAsync(string customerName);
    }
}
