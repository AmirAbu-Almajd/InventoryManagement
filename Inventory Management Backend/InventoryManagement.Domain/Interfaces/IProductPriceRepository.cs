using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Domain.Interfaces
{
    public interface IProductPriceRepository
    {
        Task<IEnumerable<ProductPrice>> GetAllAsync();
        Task<ProductPrice?> GetByIdAsync(long id);
        Task AddAsync(ProductPrice product);
        Task UpdateAsync(ProductPrice product);
        Task DeleteAsync(long id);
    }
}
