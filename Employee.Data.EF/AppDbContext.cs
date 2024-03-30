using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Employee.Models.Data.Entity;
using Employee.Data.EF.Config;

namespace Employee.Data.EF
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
		{
		}

        #region Properties
        public DbSet<EmployeeInfo> Employees { get; set; }

        // DbSet properties for your entity types
        
        //public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        //public DbSet<LeaveRequest> LeaveRequests { get; set; }
        //public DbSet<Salary> Salaries { get; set; }
        //public DbSet<Models.Data.Entity.Task> Tasks { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            //modelBuilder.ApplyConfiguration(new EmployeeInfoConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeProfileConfiguration());
            //modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeRoleConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            //modelBuilder.ApplyConfiguration(new LeaveRequestConfiguration());
            //modelBuilder.ApplyConfiguration(new TaskConfiguration());
            //modelBuilder.ApplyConfiguration(new SalaryConfiguration());
        }

        [ExcludeFromCodeCoverage]
        public void CreateDatabse()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}

