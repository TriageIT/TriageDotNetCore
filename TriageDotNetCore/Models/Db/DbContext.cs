using Microsoft.EntityFrameworkCore;

namespace TriageDotNetCore.Models.Db
{
    public class EmployeeDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
