using System;
using System.Collections.Generic;

namespace PayrollManagement.Core.Entities
{
    public class Payroll : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime Period { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public ICollection<PayrollItem>? Items { get; set; }
    }
}
