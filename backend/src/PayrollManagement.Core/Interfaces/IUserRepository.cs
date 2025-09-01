using PayrollManagement.Core.Entities;
using System.Threading.Tasks;

namespace PayrollManagement.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}
