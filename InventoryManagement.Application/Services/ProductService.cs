

using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productsRepository;

        public ProductService(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _productsRepository.GetByIdAsync(id);
        }

        public async Task AddProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Code = dto.Code,

            };
            await _productsRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Guid id, ProductDto dto)
        {
            var existing = await _productsRepository.GetByIdAsync(id);
            if (existing == null) return;

            existing.Name = dto.Name;

            await _productsRepository.UpdateAsync(existing);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productsRepository.DeleteAsync(id);
        }
    }
}
