using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SalesRecordRepository : ISalesRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesRecord>> GetAllAsync() =>
            await _context.SalesRecords.ToListAsync();

        public async Task<SalesRecord?> GetByIdAsync(long id) =>
            await _context.SalesRecords.FindAsync(id);

        public async Task AddAsync(SalesRecord salesRecord)
        {
            _context.SalesRecords.Add(salesRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SalesRecord salesRecord)
        {
            _context.SalesRecords.Update(salesRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var salesRecord = await _context.SalesRecords.FindAsync(id);
            if (salesRecord != null)
            {
                _context.SalesRecords.Remove(salesRecord);
                await _context.SaveChangesAsync();
            }
        }
    }
}
