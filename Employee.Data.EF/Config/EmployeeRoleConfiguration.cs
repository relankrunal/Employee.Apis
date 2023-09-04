using Employee.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
{
    public void Configure(EntityTypeBuilder<EmployeeRole> builder)
    {
        // Define the composite primary key
        builder.HasKey(er => new { er.EmployeeId, er.RoleId });

        // Configure the foreign key relationship with Employee
        builder.HasOne(er => er.Employee)
            .WithMany(e => e.EmployeeRoles)
            .HasForeignKey(er => er.EmployeeId);

        // Configure the foreign key relationship with Role
        builder.HasOne(er => er.Role)
            .WithMany(r => r.EmployeeRoles)
            .HasForeignKey(er => er.RoleId);

        // Define other properties and constraints as needed
        builder.Property(er => er.StartDate)
            .IsRequired();

        builder.Property(er => er.EndDate)
            .HasColumnType("date"); // You can adjust the data type as needed
    }
}
