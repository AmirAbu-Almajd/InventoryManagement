using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Application.Services
{
    public class SalesRecordService : ISalesRecordService
    {
        private readonly ISalesRecordRepository _salesRecordRepository;
        private readonly IStockRecordRepository _stockRecordRepository;
        private readonly IProductPriceRepository _productPricesRepository;
        private readonly IProductRepository _productsRepository;


        public SalesRecordService(
            ISalesRecordRepository salesRecordRepository,
            IStockRecordRepository stockRecordRepository,
            IProductPriceRepository productPricesRepository,
            IProductRepository productsRepository)
        {
            _salesRecordRepository = salesRecordRepository;
            _stockRecordRepository = stockRecordRepository;
            _productPricesRepository = productPricesRepository;
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<SalesRecordDto>> GetAllSalesRecordsAsync()
        {
            var salesRecords = await _salesRecordRepository.GetAllAsync();
            var products = await _productsRepository.GetAllAsync();

            var result = from o in salesRecords
                         join oProduct in products
                         on o.ProductId equals oProduct.Id
                         select new SalesRecordDto
                         {
                             Id = o.Id,
                             Quantity = o.Quantity,
                             Amount = o.Amount,
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

        public async Task<SalesRecordDto?> GetSalesRecordByIdAsync(long id)
        {
            var salesRecord = _salesRecordRepository.GetByIdAsync(id);
            if (salesRecord == null)
            {
                throw new InvalidOperationException("No matching sales record found.");
            }

            var product = await _productsRepository.GetByIdAsync(salesRecord.Result.ProductId);

            return new SalesRecordDto
            {
                Id = salesRecord.Result.Id,
                Quantity = salesRecord.Result.Quantity,
                Amount = salesRecord.Result.Amount,
                ProductDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    Description = product.Description
                }
            };
        }

        public async Task AddSalesRecordAsync(SalesRecordDto dto)
        {
            var stockRecord = _stockRecordRepository.GetAllAsync().Result.Where(e => e.ProductId == (Guid)dto.ProductDto.Id).FirstOrDefault();

            if (stockRecord == null || stockRecord.Quantity < dto.Quantity)
            {
                throw new InvalidOperationException("Insufficient stock.");
            }

            decimal? productPrice = _productPricesRepository.GetAllAsync().Result.Where(e => e.ProductId == (Guid)dto.ProductDto.Id).FirstOrDefault()?.Price;

            var salesRecord = new SalesRecord
            {
                Quantity = dto.Quantity,
                Amount = productPrice == null ? 0 : productPrice.Value * dto.Quantity,
                ProductId = (Guid)dto.ProductDto.Id
            };
            await _salesRecordRepository.AddAsync(salesRecord);

            stockRecord.Quantity -= salesRecord.Quantity;
            await _stockRecordRepository.UpdateAsync(stockRecord);


        }

        public async Task UpdateSalesRecordAsync(SalesRecordDto dto)
        {
            var existing = await _salesRecordRepository.GetByIdAsync((long)dto.Id);
            if (existing == null) return;

            var stockRecord = _stockRecordRepository.GetAllAsync().Result.Where(e => e.ProductId == (Guid)dto.ProductDto.Id).FirstOrDefault();

            if (dto.Quantity > existing.Quantity)
            {
                if (stockRecord == null || (stockRecord.Quantity < (dto.Quantity- existing.Quantity)))
                {
                    throw new InvalidOperationException("Insufficient stock.");
                }
            }

            decimal? productPrice = _productPricesRepository.GetAllAsync().Result.Where(e => e.ProductId == (Guid)dto.ProductDto.Id).FirstOrDefault().Price;

            existing.Quantity = dto.Quantity;
            existing.Amount = productPrice == null ? 0 : productPrice.Value * dto.Quantity;

            await _salesRecordRepository.UpdateAsync(existing);

            stockRecord.Quantity -= (dto.Quantity - existing.Quantity);
            await _stockRecordRepository.UpdateAsync(stockRecord);
        }

        public async Task DeleteSalesRecordAsync(long id)
        {
            await _salesRecordRepository.DeleteAsync(id);
        }

    }
}
