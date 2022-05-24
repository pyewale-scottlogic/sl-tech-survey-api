using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ProjectOwnerAccountOwners = new HashSet<ProjectOwner>();
            ProjectOwnerTechLeads = new HashSet<ProjectOwner>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<ProjectOwner> ProjectOwnerAccountOwners { get; set; }
        public virtual ICollection<ProjectOwner> ProjectOwnerTechLeads { get; set; }
    }
}
