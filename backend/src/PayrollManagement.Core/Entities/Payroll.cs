using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PayrollManagement.Core.Enums;

namespace PayrollManagement.Core.Entities;

public class Payroll : BaseEntity
{
    public int EmployeeId { get; set; }
    
    public int PayPeriodMonth { get; set; }
    
    public int PayPeriodYear { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal BaseSalary { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal OvertimeHours { get; set; } = 0;
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal OvertimeRate { get; set; } = 0;
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Bonus { get; set; } = 0;
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Deductions { get; set; } = 0;
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal TaxDeductions { get; set; } = 0;
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal GrossPay { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal NetPay { get; set; }
    
    public PayrollStatus Status { get; set; } = PayrollStatus.Draft;
    
    public DateTime? ProcessedDate { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    // Navigation properties
    public virtual Employee Employee { get; set; } = null!;
    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();
    
    // Computed property
    public string PayPeriod => $"{PayPeriodMonth:D2}/{PayPeriodYear}";
}