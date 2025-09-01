using PayrollManagement.Core.Common;
using PayrollManagement.Core.Entities;
using PayrollManagement.Core.Enums;

namespace PayrollManagement.Core.Interfaces;

public interface IPayrollRepository : IRepository<Payroll>
{
    Task<Payroll?> GetByEmployeeAndPeriodAsync(int employeeId, int month, int year);
    Task<bool> PayrollExistsAsync(int employeeId, int month, int year, int? excludeId = null);
    Task<Payroll?> GetWithItemsAsync(int id);
    Task<PagedResult<Payroll>> GetByEmployeeAsync(int employeeId, int pageNumber, int pageSize);
    Task<PagedResult<Payroll>> GetByPeriodAsync(int month, int year, int pageNumber, int pageSize);
    Task<PagedResult<Payroll>> GetByStatusAsync(PayrollStatus status, int pageNumber, int pageSize);
    Task<IEnumerable<Payroll>> GetPayrollsForProcessingAsync(int month, int year);
    Task<decimal> GetTotalPayrollAmountAsync(int month, int year);
    Task<IEnumerable<Payroll>> GetPayrollsSummaryAsync(int month, int year);
}