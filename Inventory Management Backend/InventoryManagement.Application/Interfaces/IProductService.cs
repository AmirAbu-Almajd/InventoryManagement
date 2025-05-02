using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(Guid id);
        Task AddProductAsync(ProductDto dto);
        Task UpdateProductAsync(ProductDto dto);
        Task DeleteProductAsync(Guid id);
    }
}
