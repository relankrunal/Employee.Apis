using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models.Data.Entity
{
	public class Task
	{
        [Key]
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public string Status { get; set; }

        // Foreign key for employee assigned to the task
        public int AssignedTo { get; set; }

        public EmployeeInfo Employee { get; set; }

        public AuditProperties AuditProperties { get; set; }
    }
}

