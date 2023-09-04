using Employee.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
{
    public void Configure(EntityTypeBuilder<Salary> builder)
    {
        // Primary key
        builder.HasKey(s => s.SalaryId);

        // Define property constraints
        builder.Property(s => s.SalaryAmount)
            .IsRequired();

        builder.Property(s => s.EffectiveDate)
            .IsRequired();

        // Configure the foreign key relationship with Employee
        builder.HasOne(s => s.Employee)
            .WithOne(e => e.Salary)
            .HasForeignKey<Salary>(s => s.EmployeeId);
    }
}
