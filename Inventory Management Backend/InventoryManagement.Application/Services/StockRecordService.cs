using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Application.Services
{
    public class StockRecordService : IStockRecordService
    {
        private readonly IStockRecordRepository _stockRecordRepository;
        private readonly IProductRepository _productsRepository;


        public StockRecordService(
            IStockRecordRepository stockRecordRepository,
            IProductRepository productsRepository)
        {
            _stockRecordRepository = stockRecordRepository;
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<StockRecordDto>> GetAllStockRecordsAsync()
        {
            var stockRecords = await _stockRecordRepository.GetAllAsync();
            var products = await _productsRepository.GetAllAsync();

            var result = from o in stockRecords
                         join oProduct in products
                         on o.ProductId equals oProduct.Id
                         select new StockRecordDto
                         {
                             Id = o.Id,
                             Quantity = o.Quantity,
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

        public async Task<StockRecordDto?> GetStockRecordByIdAsync(long id)
        {
            var stockRecord = _stockRecordRepository.GetByIdAsync(id);
            if (stockRecord == null)
            {
                throw new InvalidOperationException("No matching stock record found.");
            }

            var product = await _productsRepository.GetByIdAsync(stockRecord.Result.ProductId);

            return new StockRecordDto
            {
                Id = stockRecord.Result.Id,
                Quantity = stockRecord.Result.Quantity,
                ProductDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    Description = product.Description
                }
            };
        }

        public async Task AddStockRecordAsync(StockRecordDto dto)
        {
            var oldStockRecord = _stockRecordRepository.GetAllAsync().Result.Where(e => e.ProductId == dto.ProductDto.Id).ToList();

            if (oldStockRecord.Any())
            {
                throw new InvalidOperationException("That product has an existing stock record.");
            }

            var stockRecord = new StockRecord
            {
                Quantity = dto.Quantity,
                ProductId = (Guid)dto.ProductDto.Id
            };
            await _stockRecordRepository.AddAsync(stockRecord);
        }

        public async Task UpdateStockRecordAsync(StockRecordDto dto)
        {
            var existing = await _stockRecordRepository.GetByIdAsync((long)dto.Id);
            if (existing == null) return;

            existing.Quantity = dto.Quantity;

            await _stockRecordRepository.UpdateAsync(existing);
        }

        public async Task DeleteStockRecordAsync(long id)
        {
            await _stockRecordRepository.DeleteAsync(id);
        }

    }
}
