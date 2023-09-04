using System;
namespace Employee.Models.Data.Entity
{
	public class EmployeeRole
	{
        public int EmployeeId { get; set; }

        public EmployeeInfo Employee { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}

