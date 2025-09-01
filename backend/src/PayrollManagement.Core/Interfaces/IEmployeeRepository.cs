using PayrollManagement.Core.Common;
using PayrollManagement.Core.Entities;

namespace PayrollManagement.Core.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee?> GetByEmployeeIdAsync(string employeeId);
    Task<bool> EmployeeIdExistsAsync(string employeeId);
    Task<bool> EmailExistsAsync(string email, int? excludeId = null);
    Task<Employee?> GetWithDepartmentAsync(int id);
    Task<PagedResult<Employee>> GetByDepartmentAsync(int departmentId, int pageNumber, int pageSize);
    Task<IEnumerable<Employee>> GetActiveEmployeesAsync();
    Task<IEnumerable<Employee>> GetEmployeesByStatusAsync(EmployeeStatus status);
}