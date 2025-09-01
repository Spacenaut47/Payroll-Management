using PayrollManagement.Core.Enums;

namespace PayrollManagement.Core.DTOs.Payroll;

public class PayrollDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string EmployeeIdNumber { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public int PayPeriodMonth { get; set; }
    public int PayPeriodYear { get; set; }
    public string PayPeriod { get; set; } = string.Empty;
    public decimal BaseSalary { get; set; }
    public decimal OvertimeHours { get; set; }
    public decimal OvertimeRate { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deductions { get; set; }
    public decimal TaxDeductions { get; set; }
    public decimal GrossPay { get; set; }
    public decimal NetPay { get; set; }
    public PayrollStatus Status { get; set; }
    public DateTime? ProcessedDate { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<PayrollItemDto> PayrollItems { get; set; } = new();
}

public class PayrollItemDto
{
    public int Id { get; set; }
    public string ItemType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public bool IsPercentage { get; set; }
    public decimal? Percentage { get; set; }
    public bool IsTaxable { get; set; }
    public string? Notes { get; set; }
}