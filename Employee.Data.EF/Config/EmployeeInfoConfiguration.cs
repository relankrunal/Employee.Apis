using System;
using System.Reflection.Emit;
using Employee.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employee.Data.EF.Config
{
    public class EmployeeInfoConfiguration : IEntityTypeConfiguration<EmployeeInfo>
    {
        public void Configure(EntityTypeBuilder<EmployeeInfo> entity)
        {
            entity.ToTable("Employee", "dbo");

            entity.HasKey(p => p.EmployeeId);

            entity.Property(p => p.EmployeeId)
                  .HasColumnName("EmpId")
                  .HasColumnType("int");

            entity.OwnsOne(o => o.AuditProperties,
                auditProperties =>
                {
                    auditProperties.Property(p => p.IsActive)
                                   .HasColumnName("IsActive");

                    auditProperties.Property(p => p.IsDeleted);

                    auditProperties.Property(p => p.CreatedByUserId)
                                   .HasColumnType("int")
                                   .IsRequired();

                    auditProperties.Property(p => p.UpdatedByUserId)
                                   .HasColumnType("int");

                    auditProperties.Property(p => p.CreatedDate)
                                   .HasColumnType("datetime")
                                   .IsRequired();

                    auditProperties.Property(p => p.UpdatedDate)
                                   .HasColumnType("datetime");
                });

            entity.Navigation(o => o.AuditProperties).IsRequired();

            entity.HasOne(e => e.Profile)
                  .WithOne(ep => ep.Employee)
                  .HasForeignKey<EmployeeProfile>(ep => ep.EmployeeId);

            // Configure one-to-many relationship between Department and Employee
            //entity.HasOne(er => er.Department)
            //.WithMany(e => e.Employees)
            //.HasForeignKey(er => er.EmployeeId);

            // Configure the many-to-many relationship with Role using EmployeeRole junction table
            entity.HasMany(e => e.EmployeeRoles)
                .WithOne(er => er.Employee)
                .HasForeignKey(er => er.EmployeeId);

            // Configure the one-to-many relationship with LeaveRequest
            entity.HasMany(e => e.LeaveRequests)
                .WithOne(lr => lr.Employee)
                .HasForeignKey(lr => lr.EmployeeId);

            // Configure the one-to-one relationship with Salary
            entity.HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salary>(s => s.EmployeeId);

            // Configure the one-to-many relationship with Task
            entity.HasMany(e => e.Tasks)
                .WithOne(t => t.Employee)
                .HasForeignKey(t => t.AssignedTo);

            // Configure the many-to-many relationship with Project using EmployeeProject junction table
            entity.HasMany(e => e.EmployeeProjects)
                .WithOne(ep => ep.Employee)
                .HasForeignKey(ep => ep.EmployeeId);

        }
    }
}

