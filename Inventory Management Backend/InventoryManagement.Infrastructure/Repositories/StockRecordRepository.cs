using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StockRecordRepository : IStockRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockRecord>> GetAllAsync() =>
            await _context.StockRecords.ToListAsync();

        public async Task<StockRecord?> GetByIdAsync(long id) =>
            await _context.StockRecords.FindAsync(id);

        public async Task AddAsync(StockRecord stockRecord)
        {
            _context.StockRecords.Add(stockRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockRecord stockRecord)
        {
            _context.StockRecords.Update(stockRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            {
                var stockRecord = await _context.StockRecords.FindAsync(id);
                if (stockRecord != null)
                {
                    _context.StockRecords.Remove(stockRecord);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
