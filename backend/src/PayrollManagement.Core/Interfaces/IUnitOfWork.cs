namespace PayrollManagement.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IEmployeeRepository Employees { get; }
    IDepartmentRepository Departments { get; }
    IPayrollRepository Payrolls { get; }
    
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}