using Microsoft.EntityFrameworkCore;
using PayrollManagement.Core.Interfaces;
using PayrollManagement.Core.Entities;
using PayrollManagement.Infrastructure.Repositories;
using PayrollManagement.Infrastructure.Data;
using System.Threading.Tasks;

namespace PayrollManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository? _users;
        private IEmployeeRepository? _employees;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IEmployeeRepository Employees => _employees ??= new EmployeeRepository(_context);

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
