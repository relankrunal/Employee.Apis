using System;
namespace Employee.Models.Data.Entity
{
	public class EmployeeInfo
	{
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        // Navigation property for one-to-one relationship with EmployeeProfile
        public EmployeeProfile Profile { get; set; }

        // Foreign key for department
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        // Navigation property for many-to-many relationship with roles
        public List<EmployeeRole> EmployeeRoles { get; set; }

        // Navigation property for many-to-many relationship with projects
        public List<EmployeeProject> EmployeeProjects { get; set; }

        // Navigation property for leave requests
        public List<LeaveRequest> LeaveRequests { get; set; }

        // Navigation property for salary
        public Salary Salary { get; set; }

        public List<Task> Tasks { get; set; }

        public AuditProperties AuditProperties { get; set; }
	}
}

