using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models.Data.Entity
{
	public class Salary
	{
        [Key]
        public int SalaryId { get; set; }

        public decimal SalaryAmount { get; set; }

        public DateTime EffectiveDate { get; set; }

        // Foreign key for employee
        public int EmployeeId { get; set; }

        public EmployeeInfo Employee { get; set; }
    }
}

