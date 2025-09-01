using System;

namespace PayrollManagement.Core.DTOs.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
    }
}
