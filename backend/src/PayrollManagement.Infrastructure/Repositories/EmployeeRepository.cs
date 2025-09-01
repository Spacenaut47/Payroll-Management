using Microsoft.EntityFrameworkCore;
using PayrollManagement.Core.Entities;
using PayrollManagement.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId)
        {
            return await _dbSet.Where(e => e.DepartmentId == departmentId).ToListAsync();
        }
    }
}
