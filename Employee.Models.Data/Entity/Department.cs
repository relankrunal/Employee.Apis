using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models.Data.Entity
{
	public class Department
	{
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        // Navigation property for employees
        public List<Employees> Employees { get; set; }
    }
}

