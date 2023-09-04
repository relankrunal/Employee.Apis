using Employee.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        // Primary key
        builder.HasKey(lr => lr.RequestId);

        // Define property constraints
        builder.Property(lr => lr.StartDate)
            .IsRequired();

        builder.Property(lr => lr.EndDate)
            .IsRequired();

        builder.Property(lr => lr.Status)
            .IsRequired()
            .HasMaxLength(50); // Adjust the length as needed

        // Configure the foreign key relationship with Employee
        builder.HasOne(lr => lr.Employee)
            .WithMany(e => e.LeaveRequests)
            .HasForeignKey(lr => lr.EmployeeId);
    }
}
