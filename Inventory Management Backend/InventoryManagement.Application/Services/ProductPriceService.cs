using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Application.Services
{
    public class ProductPriceService : IProductPriceService
    {
        private readonly IProductPriceRepository _productPricesRepository;
        private readonly IProductRepository _productsRepository;


        public ProductPriceService(
            IProductPriceRepository productPricesRepository,
            IProductRepository productsRepository)
        {
            _productPricesRepository = productPricesRepository;
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<ProductPriceDto>> GetAllProductPricesAsync()
        {
            var productPrices = await _productPricesRepository.GetAllAsync();
            var products = await _productsRepository.GetAllAsync();

            var result = from o in productPrices
                         join oProduct in products
                         on o.ProductId equals oProduct.Id
                         select new ProductPriceDto
                         {
                             Id = o.Id,
                             Price = o.Price,
                             ProductDto = new ProductDto
                             {
                                 Id = oProduct.Id,
                                 Name = oProduct.Name,
                                 Code = oProduct.Code,
                                 Description = oProduct.Description
                             }

                         };
            return result.ToList();
        }

        public async Task<ProductPriceDto?> GetProductPriceByIdAsync(long id)
        {
            var productPrice = _productPricesRepository.GetByIdAsync(id);
            if (productPrice == null)
            {
                throw new InvalidOperationException("No matching product price found.");
            }

            var product = await _productsRepository.GetByIdAsync(productPrice.Result.ProductId);

            return new ProductPriceDto
            {
                Id = productPrice.Result.Id,
                Price = productPrice.Result.Price,
                ProductDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    Description = product.Description
                }
            };
        }

        public async Task AddProductPriceAsync(ProductPriceDto dto)
        {
            var oldProductPrice = _productPricesRepository.GetAllAsync().Result.Where(e => e.ProductId == dto.ProductDto.Id).ToList();
            
            if (oldProductPrice.Any())
            {
                throw new InvalidOperationException("That product has an existing price.");
            }

            else if(dto.Price < 0)
            {
                throw new InvalidOperationException("The product price cannot be negative.");
            }

            var productPrice = new ProductPrice
            {
                Price = dto.Price,
                ProductId = (Guid)dto.ProductDto.Id
            };
            await _productPricesRepository.AddAsync(productPrice);
        }

        public async Task UpdateProductPriceAsync(ProductPriceDto dto)
        {
            var existing = await _productPricesRepository.GetByIdAsync((long)dto.Id);
            if (existing == null) return;

            existing.Price = dto.Price;

            await _productPricesRepository.UpdateAsync(existing);
        }

        public async Task DeleteProductPriceAsync(long id)
        {
            await _productPricesRepository.DeleteAsync(id);
        }

    }
}
