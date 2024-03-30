using System;
using Employee.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employee.Data.EF.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeId)
                   .HasColumnName("employee_id");

            builder.Property(e => e.DepartmentId)
                   .HasColumnName("department_id");

            builder.Property(e => e.FirstName)
                   .HasColumnName("first_name");

            builder.Property(e => e.LastName)
                   .HasColumnName("last_name");

            builder.Property(e => e.Email)
                   .HasColumnName("email");

            builder.Property(e => e.DatOfBirth)
                   .HasColumnName("date_of_birth");

            builder.Property(e => e.PositionId)
                   .HasColumnName("position_id");

            builder.HasOne(e => e.Position)
               .WithMany(p => p.Employees)
               .HasForeignKey(e => e.PositionId);

            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId);

        }
    }
}

