using PayrollManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollManagement.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId);
    }
}
