using System;
namespace Employee.Models.Data.Entity
{
    public class Employees
    {
        public int EmployeeId { get; set; }

        public int DepartmentId { get; set; }

        public int PositionId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DatOfBirth { get; set; }

        public Department Department { get; set; }

        public Position Position{ get; set; }
    }
}

