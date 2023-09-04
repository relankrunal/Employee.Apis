using System;
namespace Employee.Models.Data.Entity
{
    public class AuditProperties
    {
        public int CreatedByUserId { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}

