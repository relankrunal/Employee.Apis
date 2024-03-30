using System;
namespace Employee.Models.Data.Entity
{
    public class Position
    {
        public int PositionId { get; set; }

        public string PositionTitle { get; set; }

        public decimal Salary { get; set; }

        public ICollection<Employees> Employees{ get; set; }
    }
}

