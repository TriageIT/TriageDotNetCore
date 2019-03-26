using System.Collections.Generic;

namespace TriageDotNetCore.Models
{
    public sealed class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

		public ICollection<RoleAssignment> RoleAssignments { get; set; }
    }
}
