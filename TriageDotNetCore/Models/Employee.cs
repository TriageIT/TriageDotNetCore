using System;
using System.Collections.Generic;

namespace TriageDotNetCore.Models
{
    public sealed class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<RoleAssignment> RoleAssignments { get; set; }
    }
}
