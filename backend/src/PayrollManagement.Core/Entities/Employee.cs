using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PayrollManagement.Core.Enums;

namespace PayrollManagement.Core.Entities;

public class Employee : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public string EmployeeId { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    
    [MaxLength(500)]
    public string? Address { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public DateTime HireDate { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal BaseSalary { get; set; }
    
    [MaxLength(100)]
    public string? Position { get; set; }
    
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    
    public int DepartmentId { get; set; }
    
    public int? UserId { get; set; }
    
    // Navigation properties
    public virtual Department Department { get; set; } = null!;
    public virtual User? User { get; set; }
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
    
    // Computed property
    public string FullName => $"{FirstName} {LastName}";
}