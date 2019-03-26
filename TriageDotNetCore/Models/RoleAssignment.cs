namespace TriageDotNetCore.Models
{
    public sealed class RoleAssignment
    {
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
