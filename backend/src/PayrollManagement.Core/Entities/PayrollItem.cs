using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagement.Core.Entities;

public class PayrollItem : BaseEntity
{
    public int PayrollId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string ItemType { get; set; } = string.Empty; // "Allowance", "Deduction", "Tax", etc.
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }
    
    public bool IsPercentage { get; set; } = false;
    
    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Percentage { get; set; }
    
    public bool IsTaxable { get; set; } = true;
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    // Navigation properties
    public virtual Payroll Payroll { get; set; } = null!;
}