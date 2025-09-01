using System.ComponentModel.DataAnnotations;

namespace PayrollManagement.Core.DTOs.Department;

public class CreateDepartmentDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    [MaxLength(10)]
    public string? Code { get; set; }
    
    public bool IsActive { get; set; } = true;
}