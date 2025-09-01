using PayrollManagement.Core.Entities;

namespace PayrollManagement.Core.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email);
    Task<User?> GetUserWithEmployeeAsync(int userId);
    Task UpdateLastLoginAsync(int userId, DateTime lastLogin);
}