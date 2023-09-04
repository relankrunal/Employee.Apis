using Employee.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeProfileConfiguration : IEntityTypeConfiguration<EmployeeProfile>
{
    public void Configure(EntityTypeBuilder<EmployeeProfile> builder)
    {
        // Primary key
        builder.HasKey(ep => ep.ProfileId);

        // Define property constraints
        builder.Property(ep => ep.DateOfBirth)
            .IsRequired();

        builder.Property(ep => ep.Address)
            .HasMaxLength(255); // Adjust the length as needed

        builder.Property(ep => ep.EmergencyContact)
            .HasMaxLength(100); // Adjust the length as needed

        // Configure the one-to-one relationship with Employee
        builder.HasOne(ep => ep.Employee)
            .WithOne(e => e.Profile)
            .HasForeignKey<EmployeeProfile>(ep => ep.EmployeeId);
    }
}