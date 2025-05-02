using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Interfaces
{
    public interface IProductPriceService
    {
        Task<IEnumerable<ProductPriceDto>> GetAllProductPricesAsync();
        Task<ProductPriceDto?> GetProductPriceByIdAsync(long id);
        Task AddProductPriceAsync(ProductPriceDto dto);
        Task UpdateProductPriceAsync(ProductPriceDto dto);
        Task DeleteProductPriceAsync(long id);
    }
}
