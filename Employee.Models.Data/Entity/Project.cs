using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models.Data.Entity
{
	public class Project
	{
        [Key]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // Navigation property for many-to-many relationship with employees
        public List<EmployeeProject> EmployeeProjects { get; set; }

        public AuditProperties AuditProperties{ get; set; }
    }
}

