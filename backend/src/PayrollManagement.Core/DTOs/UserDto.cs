using PayrollManagement.Core.Enums;

namespace PayrollManagement.Core.DTOs.Auth;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int? EmployeeId { get; set; }
}