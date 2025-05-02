using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductPriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductPrice>> GetAllAsync() =>
            await _context.ProductPrices.ToListAsync();

        public async Task<ProductPrice?> GetByIdAsync(long id) =>
            await _context.ProductPrices.FindAsync(id);

        public async Task AddAsync(ProductPrice productPrice)
        {
            _context.ProductPrices.Add(productPrice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductPrice productPrice)
        {
            _context.ProductPrices.Update(productPrice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var productPrice = await _context.ProductPrices.FindAsync(id);
            if (productPrice != null)
            {
                _context.ProductPrices.Remove(productPrice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
