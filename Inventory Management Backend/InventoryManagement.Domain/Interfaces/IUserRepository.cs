using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(long id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(long id);
    }
}
