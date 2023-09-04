using System;
namespace Employee.Models.Data.Entity
{
	public class EmployeeProfile
	{
        public int ProfileId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string EmergencyContact { get; set; }

        // Foreign key for employee
        public int EmployeeId { get; set; }

        public EmployeeInfo Employee { get; set; }
    }
}

