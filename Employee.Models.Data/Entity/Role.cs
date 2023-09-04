using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models.Data.Entity
{
	public class Role
	{
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        // Navigation property for many-to-many relationship with employees
        public List<EmployeeRole> EmployeeRoles { get; set; }
    }
}

