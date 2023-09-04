using Employee.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
{
    public void Configure(EntityTypeBuilder<EmployeeProject> builder)
    {
        // Define the composite primary key
        builder.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

        // Configure the foreign key relationship with Employee
        builder.HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeeProjects)
            .HasForeignKey(ep => ep.EmployeeId);

        // Configure the foreign key relationship with Project
        builder.HasOne(ep => ep.Project)
            .WithMany(p => p.EmployeeProjects)
            .HasForeignKey(ep => ep.ProjectId);

        // Define other properties and constraints as needed
        // (e.g., if you have additional properties in the junction table)
    }
}
