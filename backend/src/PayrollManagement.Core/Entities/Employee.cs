using PayrollManagement.Core.Enums;
using System;

namespace PayrollManagement.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public decimal Salary { get; set; }
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
