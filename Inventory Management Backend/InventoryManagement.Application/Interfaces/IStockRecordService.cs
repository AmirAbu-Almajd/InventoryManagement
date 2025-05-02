using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Interfaces
{
    public interface IStockRecordService
    {
        Task<IEnumerable<StockRecordDto>> GetAllStockRecordsAsync();
        Task<StockRecordDto?> GetStockRecordByIdAsync(long id);
        Task AddStockRecordAsync(StockRecordDto dto);
        Task UpdateStockRecordAsync(StockRecordDto dto);
        Task DeleteStockRecordAsync(long id);
    }
}
