using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Domain.Interfaces
{
    public interface ISalesRecordRepository
    {
        Task<IEnumerable<SalesRecord>> GetAllAsync();
        Task<SalesRecord?> GetByIdAsync(long id);
        Task AddAsync(SalesRecord product);
        Task UpdateAsync(SalesRecord product);
        Task DeleteAsync(long id);
    }
}
