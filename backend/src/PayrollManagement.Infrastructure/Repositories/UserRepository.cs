using Microsoft.EntityFrameworkCore;
using PayrollManagement.Core.Entities;
using PayrollManagement.Core.Interfaces;
using System.Threading.Tasks;

namespace PayrollManagement.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
