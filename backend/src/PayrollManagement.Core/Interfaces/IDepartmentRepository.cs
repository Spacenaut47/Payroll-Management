using PayrollManagement.Core.Entities;

namespace PayrollManagement.Core.Interfaces;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<Department?> GetByNameAsync(string name);
    Task<bool> NameExistsAsync(string name, int? excludeId = null);
    Task<bool> CodeExistsAsync(string code, int? excludeId = null);
    Task<Department?> GetWithEmployeesAsync(int id);
    Task<IEnumerable<Department>> GetActiveDepartmentsAsync();
    Task<int> GetEmployeeCountAsync(int departmentId);
}