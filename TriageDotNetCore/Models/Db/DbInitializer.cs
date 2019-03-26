using System;
using System.Linq;

namespace TriageDotNetCore.Models.Db
{
    public static class DbInitializer
    {
	    public static void Initialize(EmployeeDbContext dbContext)
	    {
		    dbContext.Database.EnsureCreated();

		    CreateRoles(dbContext);
		    CreateEmployees(dbContext);
            CreateRoleAssignments(dbContext);
	    }

	    private static void CreateRoleAssignments(EmployeeDbContext dbContext)
	    {
		    if (dbContext.RoleAssignments.Any())
		    {
			    return;
		    }

		    Employee paul = dbContext.Employees.First(employee => employee.FirstName == "paul");
		    Role baasRole = dbContext.Roles.First(role => role.RoleName == "Baas");

		    var roleAssignments = new[]
		    {
			    new RoleAssignment {EmployeeId = paul.Id, RoleId = baasRole.Id}
		    };

		    dbContext.RoleAssignments.AddRange(roleAssignments);
		    dbContext.SaveChanges();
	    }

        private static void CreateEmployees(EmployeeDbContext dbContext)
	    {
		    if (dbContext.Employees.Any())
		    {
			    return;
		    }

		    Employee[] employees =
		    {
			    new Employee
			    {
				    FirstName = "Paul",
				    LastName = "Willems",
				    StartDate = DateTime.Today,
			    }
		    };
		    dbContext.Employees.AddRange(employees);
		    dbContext.SaveChanges();
	    }

	    private static void CreateRoles(EmployeeDbContext dbContext)
	    {
		    if (dbContext.Roles.Any())
		    {
			    return;
		    }

		    var roles = new[]
		    {
			    new Role {RoleName = "Baas"},
			    new Role {RoleName = "Tester"},
			    new Role {RoleName = "Ontwikkelaar"},
			    new Role {RoleName = "Projectmanager"}
		    };

			dbContext.Roles.AddRange(roles);
		    dbContext.SaveChanges();
	    }
    }
}
