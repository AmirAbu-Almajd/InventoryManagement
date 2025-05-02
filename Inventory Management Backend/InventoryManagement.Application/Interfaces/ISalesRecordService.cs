using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Interfaces
{
    public interface ISalesRecordService
    {
        Task<IEnumerable<SalesRecordDto>> GetAllSalesRecordsAsync();
        Task<SalesRecordDto?> GetSalesRecordByIdAsync(long id);
        Task AddSalesRecordAsync(SalesRecordDto dto);
        Task UpdateSalesRecordAsync(SalesRecordDto dto);
        Task DeleteSalesRecordAsync(long id);
    }
}
