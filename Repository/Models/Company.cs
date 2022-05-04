using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Company
    {
        public Company()
        {
            Projects = new HashSet<Project>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
