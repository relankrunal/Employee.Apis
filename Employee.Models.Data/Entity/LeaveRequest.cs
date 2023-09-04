using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models.Data.Entity
{
	public class LeaveRequest
	{
        [Key]
        public int RequestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        // Foreign key for employee
        public int EmployeeId { get; set; }

        public EmployeeInfo Employee { get; set; }
    }
}

