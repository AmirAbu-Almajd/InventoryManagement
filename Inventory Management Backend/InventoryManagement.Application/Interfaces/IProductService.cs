using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid id);
        Task AddProductAsync(ProductDto dto);
        Task UpdateProductAsync(Guid id, ProductDto dto);
        Task DeleteProductAsync(Guid id);
    }
}
