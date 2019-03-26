using Microsoft.EntityFrameworkCore;

namespace TriageDotNetCore.Models.Db
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Role> Roles { get; set; }

		public DbSet<RoleAssignment> RoleAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<RoleAssignment>()
		        .HasKey(assignment => new {assignment.EmployeeId, assignment.RoleId});

	        modelBuilder.Entity<RoleAssignment>()
		        .HasOne(assignment => assignment.Employee)
		        .WithMany(employee => employee.RoleAssignments)
		        .HasForeignKey(assignment => assignment.EmployeeId);

	        modelBuilder.Entity<RoleAssignment>()
		        .HasOne(assignment => assignment.Role)
		        .WithMany(role => role.RoleAssignments)
		        .HasForeignKey(assignment => assignment.RoleId);
        }
    }
}
