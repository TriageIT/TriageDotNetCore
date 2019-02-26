using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriageDotNetCore.Models.Db
{
    public static class DbInitializer
    {
	    public static void Initialize(EmployeeDbContext dbContext)
	    {
		    dbContext.Database.EnsureCreated();

		    if (!dbContext.Roles.Any())
		    {
			    var roles = new[]
			    {
				    new Role {RoleName = "Baas"},
				    new Role {RoleName = "Tester"},
				    new Role {RoleName = "Ontwikkelaar"},
				    new Role {RoleName = "Projectmanager"}
			    };

			    foreach (Role role in roles)
			    {
				    dbContext.Roles.Add(role);
			    }

			    dbContext.SaveChanges();
		    }

		    if (dbContext.Employees.Any())
		    {
			    return;
		    }

		    var paul = new Employee
		    {
			    FirstName = "Paul",
			    LastName = "Willems",
			    StartDate = DateTime.MinValue,
				Roles = new List<Role>()
		    };

		    paul.Roles.Add(dbContext.Roles.First(role => role.RoleName == "Baas"));

            Employee[] employees = { paul };

		    foreach (Employee employee in employees)
		    {
			    dbContext.Employees.Add(employee);
		    }

		    dbContext.SaveChanges();
	    }
    }
}
