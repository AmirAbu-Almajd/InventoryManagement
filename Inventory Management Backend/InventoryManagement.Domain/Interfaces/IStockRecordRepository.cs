using InventoryManagement.Domain.Entities;


namespace InventoryManagement.Domain.Interfaces
{
    public interface IStockRecordRepository
    {
        Task<IEnumerable<StockRecord>> GetAllAsync();
        Task<StockRecord?> GetByIdAsync(long id);
        Task AddAsync(StockRecord stockRecord);
        Task UpdateAsync(StockRecord stockRecord);
        Task DeleteAsync(long id);
    }
}
