using System;
using System.Threading.Tasks;

namespace PayrollManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IEmployeeRepository Employees { get; }
        Task<int> CommitAsync();
    }
}
