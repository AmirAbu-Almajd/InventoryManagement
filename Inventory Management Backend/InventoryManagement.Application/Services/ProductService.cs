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

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var res = await _productsRepository.GetAllAsync();
            return res.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Code = p.Code
            }).ToList();
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)
        {
            var res = await _productsRepository.GetByIdAsync(id);
            return new ProductDto
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description,
                Code = res.Code
            };
        }

        public async Task AddProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description
            };
            await _productsRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto dto)
        {
            var existing = await _productsRepository.GetByIdAsync((Guid)dto.Id);
            if (existing == null) return;

            existing.Name = dto.Name;
            existing.Code = dto.Code;
            existing.Description = dto.Description;

            await _productsRepository.UpdateAsync(existing);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productsRepository.DeleteAsync(id);
        }
    }
}
