using System.ComponentModel.DataAnnotations;
using PayrollManagement.Core.Enums;

namespace PayrollManagement.Core.Entities;

public class User : BaseEntity
{
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
    
    [Required]
    public string PasswordHash { get; set; } = string.Empty;
    
    [Required]
    public UserRole Role { get; set; } = UserRole.Employee;
    
    public bool IsActive { get; set; } = true;
    
    public DateTime? LastLoginAt { get; set; }
    
    // Navigation property
    public Employee? Employee { get; set; }
    
    // Computed property
    public string FullName => $"{FirstName} {LastName}";
}