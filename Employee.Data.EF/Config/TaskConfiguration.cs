using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Employee.Models.Data.Entity.Task;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        // Primary key
        builder.HasKey(t => t.TaskId);

        // Define property constraints
        builder.Property(t => t.TaskName)
            .IsRequired()
            .HasMaxLength(100); // Adjust the length as needed

        builder.Property(t => t.Description)
            .HasMaxLength(255); // Adjust the length as needed

        builder.Property(t => t.Deadline)
            .IsRequired();

        builder.Property(t => t.Status)
            .IsRequired()
            .HasMaxLength(50); // Adjust the length as needed

        // Configure the foreign key relationship with Employee
        builder.HasOne(t => t.Employee)
            .WithMany(e => e.Tasks)
            .HasForeignKey(t => t.AssignedTo);
    }
}
