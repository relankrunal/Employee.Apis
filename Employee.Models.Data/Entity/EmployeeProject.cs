using System;
namespace Employee.Models.Data.Entity
{
	public class EmployeeProject
	{
        public int EmployeeId { get; set; }

        public EmployeeInfo Employee { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}

