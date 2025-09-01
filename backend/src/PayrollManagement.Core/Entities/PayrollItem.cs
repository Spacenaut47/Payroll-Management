namespace PayrollManagement.Core.Entities
{
    public class PayrollItem : BaseEntity
    {
        public int PayrollId { get; set; }
        public Payroll? Payroll { get; set; }
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }
        public bool IsDeduction { get; set; }
    }
}
