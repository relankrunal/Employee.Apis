using Employee.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        // Primary key
        builder.HasKey(d => d.DepartmentId);

        // Define property constraints
        builder.Property(d => d.DepartmentName)
            .IsRequired()
            .HasMaxLength(100); // Adjust the length as needed

        // Configure the one-to-many relationship with Employee
        builder.HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId);
    }
}
