using System.ComponentModel.DataAnnotations;
using PayrollManagement.Core.Enums;

namespace PayrollManagement.Core.DTOs.Employee;

public class UpdateEmployeeDto
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    
    [MaxLength(500)]
    public string? Address { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Base salary must be a positive number")]
    public decimal BaseSalary { get; set; }
    
    [MaxLength(100)]
    public string? Position { get; set; }
    
    public EmployeeStatus Status { get; set; }
    
    [Required]
    public int DepartmentId { get; set; }
}